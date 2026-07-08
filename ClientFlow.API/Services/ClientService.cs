using AutoMapper;
using ClientFlow.API.Data;
using ClientFlow.API.Entities;
using ClientFlow.API.Contracts;
using ClientFlow.Shared.DTOs.Client;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.API.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public ClientService(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> GetClientsAsync() =>
        mapper.Map<IEnumerable<ClientDTO>>(await context.Clients.ToListAsync());

    public async Task<ClientDTO> GetClientAsync(int id) =>
        mapper.Map<ClientDTO>(await context.Clients.Include(x => x.ClientNotes).FirstOrDefaultAsync(x => x.Id == id));


    public async Task<ClientDTO> CreateClientAsync(CreateClientDTO clientDTO)
    {
        var client = mapper.Map<Client>(clientDTO);

        context.Add(client);
        await context.SaveChangesAsync();

        return mapper.Map<ClientDTO>(client);
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        var result = await context.Clients.Where(x => x.Id == id).ExecuteDeleteAsync();

        return result > 0;
    }

}

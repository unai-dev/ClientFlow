using AutoMapper;
using ClientFlow.API.Data;
using ClientFlow.API.Entities;
using ClientFlow.API.Interfaces;
using ClientFlow.Shared.DTOs.ClientNote;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.API.Services
{
    public class ClientNoteService : IClientNoteService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientNoteService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClientNoteDTO>> GetClientNotesAsync(int clientId)
        {
            var notes = await context.ClientNotes.Where(x => x.ClientId == clientId).ToListAsync();

            return mapper.Map<IEnumerable<ClientNoteDTO>>(notes);
        }

        public async Task<ClientNoteDTO> CreateClientNoteAsync(int clientId, CreateClientNoteDTO clientNoteDTO)
        {
            var client = await context.Clients.AnyAsync(x => x.Id == clientId);

            if (!client)
            {
                return null!;
            }

            var note = mapper.Map<ClientNote>(clientNoteDTO);

            note.ClientId = clientId;

            context.Add(note);

            await context.SaveChangesAsync();

            return mapper.Map<ClientNoteDTO>(note);
        }

        public async Task<bool> DeleteClientNoteAsync(Guid id)
        {

            var result = await context.ClientNotes.Where(x => x.Id == id).ExecuteDeleteAsync();

            return result > 0;

        }


    }
}

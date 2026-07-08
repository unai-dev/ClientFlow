using AutoMapper;
using ClientFlow.API.Contracts;
using ClientFlow.API.Data;
using ClientFlow.API.Entities;
using ClientFlow.Shared.DTOs.User;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.API.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public UserService(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetUsersAsync() =>
        mapper.Map<IEnumerable<UserDTO>>(await context.Users.ToListAsync());
    public async Task<UserDTO> GetUserAsync(int id) =>
        mapper.Map<UserDTO>(await context.Users.FirstOrDefaultAsync(x => x.Id == id));

    public async Task<UserDTO> CreateUserAsync(CreateUserDTO userDTO)
    {
        var user = mapper.Map<User>(userDTO);

        context.Add(user);
        await context.SaveChangesAsync();

        return mapper.Map<UserDTO>(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var result = await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();

        return result > 0;
    }

}


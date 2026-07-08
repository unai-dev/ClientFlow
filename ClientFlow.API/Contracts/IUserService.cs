using ClientFlow.Shared.DTOs.User;

namespace ClientFlow.API.Contracts
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(CreateUserDTO userDTO);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDTO> GetUserAsync(int id);
        Task<IEnumerable<UserDTO>> GetUsersAsync();
    }
}
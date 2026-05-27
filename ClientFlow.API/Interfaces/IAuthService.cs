using ClientFlow.Shared.DTOs.Auth;

namespace ClientFlow.API.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDTO> Login(CredentialsDTO credentialsDTO);
        Task<ResponseDTO> Register(CredentialsDTO credentialsDTO);
    }
}
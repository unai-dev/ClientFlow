using ClientFlow.Shared.DTOs.Auth;

namespace ClientFlow.API.Contracts;

public interface IAuthService
{
    Task<ResponseDTO> Login(CredentialsDTO credentialsDTO);
    Task<ResponseDTO> Register(CredentialsDTO credentialsDTO);
}

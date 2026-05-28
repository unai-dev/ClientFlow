using ClientFlow.Shared.DTOs.Auth;

namespace ClientFlow.UI.Features.Auth.Services
{
    public interface IAuthService
    {
        Task<ResponseDTO?> Login(CredentialsDTO credentials);
        Task<ResponseDTO?> Register(CredentialsDTO credentials);
    }
}
using ClientFlow.Shared.DTOs.Auth;
using System.Net.Http.Json;

namespace ClientFlow.UI.Features.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;

        public AuthService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseDTO?> Register(CredentialsDTO credentials)
        {
            var response = await httpClient.PostAsJsonAsync("auth/register", credentials);

            return await response.Content.ReadFromJsonAsync<ResponseDTO>();
        }

        public async Task<ResponseDTO?> Login(CredentialsDTO credentials)
        {
            var response = await httpClient.PostAsJsonAsync("auth/login", credentials);

            return await response.Content.ReadFromJsonAsync<ResponseDTO>();
        }
    }
}

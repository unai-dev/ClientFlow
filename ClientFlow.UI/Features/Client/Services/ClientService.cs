using ClientFlow.Shared.DTOs.Client;
using ClientFlow.UI.Features.Client.Interfaces;
using System.Net.Http.Json;

namespace ClientFlow.UI.Features.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient httpClient;

        public ClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<List<ClientDTO?>> GetClientsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<ClientDTO?>>("clients") ?? new List<ClientDTO>()!;
        }

        public async Task<ClientDTO?> GetClientAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<ClientDTO?>($"clients/{id}");
        }

        public async Task<ClientDTO?> CreateClientAsync(CreateClientDTO clientDTO)
        {
            var response = await httpClient.PostAsJsonAsync("clients", clientDTO);

            return await response.Content.ReadFromJsonAsync<ClientDTO>();
        }

        public async Task<bool?> DeleteClientAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"clients/{id}");

            return response.IsSuccessStatusCode;

        }
    }

}
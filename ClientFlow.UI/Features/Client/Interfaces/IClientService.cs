using ClientFlow.Shared.DTOs.Client;

namespace ClientFlow.UI.Features.Client.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO?> CreateClientAsync(CreateClientDTO clientDTO);
        Task<bool?> DeleteClientAsync(int id);
        Task<ClientDTO?> GetClientAsync(int id);
        Task<List<ClientDTO?>> GetClientsAsync();
    }
}
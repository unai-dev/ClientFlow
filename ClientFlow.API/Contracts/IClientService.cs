using ClientFlow.Shared.DTOs.Client;

namespace ClientFlow.API.Contracts;

public interface IClientService
{
    Task<ClientDTO> CreateClientAsync(CreateClientDTO clientDTO);
    Task<bool> DeleteClientAsync(int id);
    Task<ClientDTO> GetClientAsync(int id);
    Task<IEnumerable<ClientDTO>> GetClientsAsync();
}
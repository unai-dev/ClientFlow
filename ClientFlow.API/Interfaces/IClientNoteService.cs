using ClientFlow.Shared.DTOs.ClientNote;

namespace ClientFlow.API.Interfaces
{
    public interface IClientNoteService
    {
        Task<ClientNoteDTO> CreateClientNoteAsync(int clientId, CreateClientNoteDTO clientNoteDTO);
        Task<bool> DeleteClientNoteAsync(int clientId, Guid id);
        Task<IEnumerable<ClientNoteDTO>> GetClientNotesAsync(int clientId);
    }
}
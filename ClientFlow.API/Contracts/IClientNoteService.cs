using ClientFlow.Shared.DTOs.ClientNote;

namespace ClientFlow.API.Contracts;

public interface IClientNoteService
{
    Task<ClientNoteDTO> CreateClientNoteAsync(int clientId, CreateClientNoteDTO clientNoteDTO);
    Task<bool> DeleteClientNoteAsync(int id);
    Task<IEnumerable<ClientNoteDTO>> GetClientNotesAsync(int clientId);
}


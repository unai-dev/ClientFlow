using ClientFlow.Shared.DTOs.ClientNote;

namespace ClientFlow.UI.Features.ClientNotes.Interfaces
{
    public interface IClientNotesService
    {
        Task<ClientNoteDTO?> CreateClientNoteAsync(int clientId, CreateClientNoteDTO noteDTO);
        Task<bool?> DeleteClientNoteAsync(Guid id);
        Task<List<ClientNoteDTO?>> GetClientNotesAsync(int clientId);
    }
}
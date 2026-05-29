using ClientFlow.Shared.DTOs.ClientNote;

namespace ClientFlow.UI.Features.ClientNotes.Models
{
    public record AddNoteRequest(int clientId, CreateClientNoteDTO addNoteDTO);
}

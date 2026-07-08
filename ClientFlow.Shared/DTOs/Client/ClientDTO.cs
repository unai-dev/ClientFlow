using ClientFlow.Shared.DTOs.ClientNote;
using System.ComponentModel.DataAnnotations;

namespace ClientFlow.Shared.DTOs.Client;

public class ClientDTO: BaseGetDTO
{
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public string? SurName2 { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? Company { get; set; }
    public string? Position { get; set; }

    public List<ClientNoteDTO> ClientNotes { get; set; } = new List<ClientNoteDTO>();
}

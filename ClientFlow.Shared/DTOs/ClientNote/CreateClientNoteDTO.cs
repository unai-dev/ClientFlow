using System.ComponentModel.DataAnnotations;

namespace ClientFlow.Shared.DTOs.ClientNote;

public class CreateClientNoteDTO: BaseCreateDTO
{
    [Required, MaxLength(255)]
    public string? Content { get; set; }
    public int ClientId { get; set; }
}

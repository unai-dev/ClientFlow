using ClientFlow.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ClientFlow.API.Entities;

public class Client: BaseEntity
{
    [Required, MaxLength(55)]
    public string? Name { get; set; }
    [Required, MaxLength(55)]
    public string? SurName { get; set; }
    [MaxLength(55)]
    public string? SurName2 { get; set; }

    [Required, EmailAddress]
    public string? Email { get; set; }
    [Required]
    public int Phone { get; set; }

    // company properties
    [Required, MaxLength(255)]
    public string? Company { get; set; }
    [Required, MaxLength(255)]
    public string? Position { get; set; }

    // related properties
    public List<ClientNote> ClientNotes { get; set; } = new List<ClientNote>();
}

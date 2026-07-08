using System.ComponentModel.DataAnnotations;

namespace ClientFlow.Shared.DTOs.Client;

public class CreateClientDTO : BaseCreateDTO
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

}

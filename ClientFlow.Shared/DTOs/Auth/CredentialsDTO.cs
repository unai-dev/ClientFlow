using System.ComponentModel.DataAnnotations;

namespace ClientFlow.Shared.DTOs.Auth;

public class CredentialsDTO
{
    [Required, MaxLength(50)]
    public string? NickName { get; set; }

    [Required, EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}

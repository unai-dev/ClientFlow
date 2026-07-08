using System.ComponentModel.DataAnnotations;

namespace ClientFlow.Shared.DTOs.User;

public class CreateUserDTO: BaseCreateDTO
{
    [Required, MaxLength(50)]
    public string? NickName { get; set; }
    [Required, EmailAddress]
    public string? Email { get; set; }
    [Required, MinLength(8)]
    public string? Password { get; set; }
}

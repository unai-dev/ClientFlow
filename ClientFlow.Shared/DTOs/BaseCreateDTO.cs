namespace ClientFlow.Shared.DTOs;

public class BaseCreateDTO
{
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

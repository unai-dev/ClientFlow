using ClientFlow.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ClientFlow.API.Entities;

public class ClientNote: BaseEntity
{
    [Required, MaxLength(255)]
    public string? Content { get; set; }

    // realated properties
    public Client? Client { get; set; }
    public int ClientId { get; set; }

}

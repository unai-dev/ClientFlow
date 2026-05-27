using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientFlow.Shared.DTOs.ClientNote
{
    public class CreateClientNoteDTO
    {
        [Required(ErrorMessage = "The field {0} is required"), MinLength(10)]
        public string? Content { get; set; }
        public int ClientId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientFlow.Shared.DTOs.Client
{
    public class CreateClientDTO
    {
        [Required(ErrorMessage = "The field {0} is required"), MinLength(5)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "The field {0} is required"), EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public long Phone { get; set; }

        public string? Company { get; set; }
        public string? Position { get; set; }

    }
}

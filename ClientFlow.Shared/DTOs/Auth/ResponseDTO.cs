using System;
using System.Collections.Generic;
using System.Text;

namespace ClientFlow.Shared.DTOs.Auth
{
    public class ResponseDTO
    {
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
    }
}

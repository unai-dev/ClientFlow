using System;
using System.Collections.Generic;
using System.Text;

namespace ClientFlow.Shared.DTOs.ClientNote
{
    public class ClientNoteDTO
    {
        public Guid Id { get; set; }

        public string? Content { get; set; }

        public int ClientId { get; set; }
    }
}

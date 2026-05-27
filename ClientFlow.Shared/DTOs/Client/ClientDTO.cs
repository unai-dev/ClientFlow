using ClientFlow.Shared.DTOs.ClientNote;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientFlow.Shared.DTOs.Client
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public long? Phone { get; set; }

        public string? Company { get; set; }
        public string? Position { get; set; }

        public List<ClientNoteDTO> ClientNotes { get; set; } = new List<ClientNoteDTO>();
    }
}

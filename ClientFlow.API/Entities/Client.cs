namespace ClientFlow.API.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public long Phone { get; set; }

        public string? Company { get; set; }
        public string? Position { get; set; }

        public List<ClientNote> ClientNotes { get; set; } = new List<ClientNote>();
    }
}

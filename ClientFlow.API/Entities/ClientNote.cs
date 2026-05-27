namespace ClientFlow.API.Entities
{
    public class ClientNote
    {
        public Guid Id { get; set; }

        public string? Content { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }

    }
}

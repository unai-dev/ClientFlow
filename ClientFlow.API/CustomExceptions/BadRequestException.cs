namespace ClientFlow.API.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string? message) : base(message)
        {

        }
    }
}

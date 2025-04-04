namespace News_Portal.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}

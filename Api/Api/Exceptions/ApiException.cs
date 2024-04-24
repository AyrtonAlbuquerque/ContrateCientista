namespace Api.Exceptions
{
    public class ApiException(string message, int statusCode, Exception exception = null) : Exception(message, exception)
    {
        public int StatusCode { get; set; } = statusCode;
        public string Details { get; set; } = (exception?.InnerException ?? exception)?.Message;
    }
}
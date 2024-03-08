namespace Api.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string Details { get; set; }

        public ApiException(string message, int statusCode, Exception exception = null) : base(message, exception)
        {
            StatusCode = statusCode;
            Details = (exception?.InnerException ?? exception)?.Message;
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Api.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message, int statusCode = 400, Exception exception = null) : base(message, statusCode, exception)
        {
        }

        public static void ThrowIfNull([NotNull] object argument, string message, int statusCode = 400, Exception innerException = null, [CallerArgumentExpression(nameof(argument))] string paramName = null)
        {
            if (argument is null) throw new ApiException(message is null ? paramName : message, statusCode, innerException);
        }

        public static void Throw(string message, int statusCode = 400, Exception innerException = null)
        {
            throw new ApiException(message, statusCode, innerException);
        }
    }
}
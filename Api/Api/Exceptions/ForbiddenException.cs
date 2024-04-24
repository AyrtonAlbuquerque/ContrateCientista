using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Api.Exceptions
{
    public class ForbiddenException(string message, int statusCode = 403, Exception exception = null) : ApiException(message, statusCode, exception)
    {
        public static void ThrowIfNull([NotNull] object argument, string message, int statusCode = 403, Exception innerException = null, [CallerArgumentExpression(nameof(argument))] string paramName = null)
        {
            if (argument is null) throw new ApiException(message ?? paramName, statusCode, innerException);
        }

        public static void ThrowIf(bool condition, string message, int statusCode = 400, Exception innerException = null, [CallerArgumentExpression(nameof(condition))] string paramName = null)
        {
            if (condition) throw new ApiException(message ?? paramName, statusCode, innerException);
        }

        public static void Throw(string message, int statusCode = 403, Exception innerException = null)
        {
            throw new ApiException(message, statusCode, innerException);
        }
    }
}
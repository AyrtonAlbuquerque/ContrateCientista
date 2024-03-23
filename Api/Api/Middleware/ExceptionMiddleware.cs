using Api.Contracts.Common;
using Api.Exceptions;

namespace Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Exception occurred: Message: {Message}, Details: {Details}", e.Message, e is ApiException e1 ? e1.Details : e.InnerException?.Message);

                context.Response.StatusCode = e is ApiException e2 ? e2.StatusCode : StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(new Error
                {
                    Message = e.Message,
                    Details = e is ApiException ex ? ex.Details : e.InnerException?.Message
                });
            }
        }
    }
}
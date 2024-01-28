using System.Net;

namespace User_Administration_Api.Middlewares
{
    public class ExceptionsMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public int ErrorMessage { get; private set; }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptions(context, ex);
            }
        }

        private static async Task HandleExceptions(HttpContext context, Exception ex)
        {
            var response = context.Response;
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = ex.Message;

            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            await response.WriteAsJsonAsync(new { ErrorMessage = message});
        }
    }
}

using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NZWalks.API.MiddelWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {

                var errorId = Guid.NewGuid();

                //log this Exception
                logger.LogError(ex, $"{errorId}  : {ex.Message}");

                //Return A Custom Error Responce    

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something want wrong! We are looking into resolving this. "
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }


        }
    }
}

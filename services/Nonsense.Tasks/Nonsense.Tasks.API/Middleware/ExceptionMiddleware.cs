using System.Net;
using System.Text.Json;
using Nonsense.Common.Errors;

namespace Nonsense.Tasks.API.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    private readonly IWebHostEnvironment _environment;

    public ExceptionMiddleware(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var errorResponse = ex switch
            {
                ModelValidationException modelException => new ApiErrorResponse(HttpStatusCode.BadRequest,
                    modelException.ErrorCode, modelException.StackTrace),
                ModelNotFoundException notFound => new ApiErrorResponse(HttpStatusCode.NotFound, notFound.ErrorCode,
                    notFound.StackTrace),
                BaseApiErrorException baseException => new ApiErrorResponse(HttpStatusCode.InternalServerError,
                    baseException.ErrorCode, baseException.StackTrace),
                _ => new ApiErrorResponse(HttpStatusCode.InternalServerError, ErrorCodes.UnknownError, ex.StackTrace)
            };

            if (_environment.IsProduction())
            {
                errorResponse.StackTrace = null;
            }

            context.Response.StatusCode = (int)errorResponse.HttpStatusCode;
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
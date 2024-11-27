using System.Net;

namespace Nonsense.Tasks.API;

public record ApiErrorResponse(HttpStatusCode HttpStatusCode, string ErrorCode, string? StackTrace)
{
    public string? StackTrace { get; set; } = StackTrace;
}
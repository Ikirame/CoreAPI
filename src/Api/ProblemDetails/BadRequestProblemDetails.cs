using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Api.ProblemDetails;

[ExcludeFromCodeCoverage]
internal sealed class BadRequestProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }
    
    public BadRequestProblemDetails(IReadOnlyDictionary<string, string[]> errors)
    {
        Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-400-bad-request";
        Title = "One or more validation errors occurred.";
        Errors = errors;
        Status = (int)HttpStatusCode.BadRequest;
    }
}
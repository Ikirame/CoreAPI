using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Api.ProblemDetails;

[ExcludeFromCodeCoverage]
internal sealed class ConflictProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public ConflictProblemDetails(string detail)
    {
        Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-409-conflict";
        Title = "Conflict";
        Detail = detail;
        Status = (int)HttpStatusCode.Conflict;
    }
}
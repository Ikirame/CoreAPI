using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Api.ProblemDetails;

[ExcludeFromCodeCoverage]
public sealed class NotFoundProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public NotFoundProblemDetails(string detail)
    {
        Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found";
        Title = "Not Found";
        Detail = detail;
        Status = (int)HttpStatusCode.NotFound;
    }
}
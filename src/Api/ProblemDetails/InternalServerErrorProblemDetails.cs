using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Api.ProblemDetails;

[ExcludeFromCodeCoverage]
public sealed class InternalServerErrorProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public InternalServerErrorProblemDetails()
    {
        Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error";
        Title = "An error occured while processing your request";
        Status = (int)HttpStatusCode.InternalServerError;
    }
}
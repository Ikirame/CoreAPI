using Api.ProblemDetails;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]s")]
public abstract class ApiController : ControllerBase
{
    public NotFoundObjectResult NotFound(string detail) => new(new NotFoundProblemDetails(detail));
    public BadRequestObjectResult BadRequest(IReadOnlyDictionary<string, string[]> errors) => new(new BadRequestProblemDetails(errors));
    public ConflictObjectResult Conflict(string detail) => new(new ConflictProblemDetails(detail));
}
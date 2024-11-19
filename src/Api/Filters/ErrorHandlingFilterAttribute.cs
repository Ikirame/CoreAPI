using System.Diagnostics.CodeAnalysis;
using Api.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

[ExcludeFromCodeCoverage]
public sealed class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new InternalServerErrorProblemDetails());
        context.ExceptionHandled = true;
    }
}
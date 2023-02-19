using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Diagnostics;

using TecnicalTest.FIGroup.Domain.Common.Constants;

namespace TecnicalTest.FIGroup.UI.Api.Filters;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        HandleUnknownException(context);
        base.OnException(context);
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Type = Values.UnknownExceptionErrorType,
            Title = Values.UnknownExceptionErrorTitle,
            Status = StatusCodes.Status500InternalServerError,
            Detail = Values.UnknownExceptionErrorDetail,
            Extensions =
            {
                ["traceId"] = Activity.Current?.Id
            }
        };
        context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status500InternalServerError };

    }

}


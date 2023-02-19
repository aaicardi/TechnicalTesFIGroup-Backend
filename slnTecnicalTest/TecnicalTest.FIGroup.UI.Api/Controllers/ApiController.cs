using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using TecnicalTest.FIGroup.Contracts.Dtos;
using TecnicalTest.FIGroup.Domain.Common.Constants;

namespace TecnicalTest.FIGroup.UI.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ValidationModelResponseDto))]
public class ApiController : ControllerBase
{

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0) return Problem();

        if (errors.All(error => error.Type == ErrorType.Validation)) return ValidationProblem(errors);

        HttpContext.Items[Values.Errors] = errors;

        return Problem(errors[0]);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Code, detail: error.Description);
    }

    public override ActionResult ValidationProblem(string? detail = null, string? instance = null,
    int? statusCode = null,
    string? title = null, string? type = null, ModelStateDictionary? modelStateDictionary = null)
    {
        modelStateDictionary ??= ModelState;

        var validationProblem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };
        var listOfErrors = modelStateDictionary
            .Select(validationErrors => new ValidationErrors
            {
                Key = validationErrors.Key.Replace("Request.", ""),
                Problems = validationErrors.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
            })
            .ToList();
        validationProblem.Extensions.Add("traceId", Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        validationProblem.Extensions.Add("errors", listOfErrors);

        if (validationProblem is { Status: 400 })
            return new BadRequestObjectResult(validationProblem);

        return new ObjectResult(validationProblem)
        {
            StatusCode = validationProblem.Status
        };
    }


    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors)
            modelStateDictionary.AddModelError
            (
                error.Code,
                error.Description
            );

        return ValidationProblem
        (
            type: Values.ValidationErrorType,
            title: Values.ValidationErrorTitle,
            detail: Values.ValidationErrorMessage,
            statusCode: StatusCodes.Status400BadRequest,
            modelStateDictionary: modelStateDictionary
        );
    }

}


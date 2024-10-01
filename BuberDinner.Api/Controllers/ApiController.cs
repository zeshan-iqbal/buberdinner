using BuberDinner.Api.Common.Http;

using ErrorOr;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Authorize]
public abstract class ApiController: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {

        if(errors.Count == 0)
        {
            return Problem();
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];

        if (errors.All(x => x.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        return Problem(firstError);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelstate = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelstate.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelstate);
    }
}
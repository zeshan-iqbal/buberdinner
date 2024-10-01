using BuberDinner.Application.Common.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {

        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            EmailNotAvailableException => (StatusCodes.Status409Conflict, "email already exists."),
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, exception?.Message ?? "Something went wrong while processing the request."),
        };

        return Problem(statusCode: statusCode, title: message);
    }
}
using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class InvalidUserException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "invalid username or password.";
}
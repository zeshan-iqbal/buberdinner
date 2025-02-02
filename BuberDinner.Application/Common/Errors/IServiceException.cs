using System.Net;

namespace BuberDinner.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; private set; }
    public string ErrorMessage { get; private set; }
}
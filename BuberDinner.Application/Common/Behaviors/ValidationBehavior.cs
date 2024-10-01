using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.Logging;

namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(
        ILogger<ValidationBehavior<TRequest, TResponse>> logger,
        IValidator<TRequest>? validator = null)
    {
        this._logger = logger;
        this._validator = validator;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

        if (_validator is null)
        {
            _logger.LogError("validator is null");
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validation => Error.Validation(
                validation.PropertyName,
                validation.ErrorMessage));

        return (dynamic)errors;
    }
}
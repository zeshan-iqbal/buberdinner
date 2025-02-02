using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries;

public sealed class LoginQueryValidator: AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
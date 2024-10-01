using BuberDinner.Application.Common.Contracts.Authentication;
using BuberDinner.Application.Common.Contracts.Persistence;
using BuberDinner.Application.Common.Services;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using ErrorOr;

namespace BuberDinner.Application.Authentication;
sealed class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
    {
        this._jwtTokenGenerator = jwtTokenGenerator;
        this._userRepository = userRepository;
        this._dateTimeProvider = dateTimeProvider;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {

        if(_userRepository.FindUserByEmail(email) is not User user 
            || user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // validate new user (user not exists and values are okay).
        if(_userRepository.FindUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(firstName, lastName, email, password, _dateTimeProvider.UtcNow);

        _userRepository.Add(user);

        // generate token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}

using BuberDinner.Application.Common.Contracts.Authentication;
using BuberDinner.Application.Common.Contracts.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Queries;

public record LoginQuery(
    string Email,
    string Password): IRequest<ErrorOr<AuthenticationResult>>
{
    private class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this._userRepository = userRepository;
            this._jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.FindUserByEmail(query.Email) is not User user
                || user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
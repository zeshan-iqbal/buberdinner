using BuberDinner.Application.Common.Contracts.Authentication;
using BuberDinner.Application.Common.Contracts.Persistence;
using BuberDinner.Application.Common.Services;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password): IRequest<ErrorOr<AuthenticationResult>>
{
    private class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IDateTimeProvider _dateTimeProvider;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IDateTimeProvider dateTimeProvider)
        {
            this._userRepository = userRepository;
            this._jwtTokenGenerator = jwtTokenGenerator;
            this._dateTimeProvider = dateTimeProvider;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // validate new user (user not exists and values are okay).
            if (_userRepository.FindUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password, _dateTimeProvider.UtcNow);

            _userRepository.Add(user);

            // generate token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
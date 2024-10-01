using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Contracts.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
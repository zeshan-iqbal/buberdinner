using BuberDinner.Application.Common.Contracts.Persistence;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository : IUserRepository
{

    private static readonly List<User> Users = new();

    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? FindUserByEmail(string email)
    {
        return Users.SingleOrDefault(x => x.Email == email);
    }
}
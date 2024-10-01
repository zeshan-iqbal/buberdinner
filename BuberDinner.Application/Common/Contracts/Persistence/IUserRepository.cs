using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Contracts.Persistence;

public interface IUserRepository
{
    User? FindUserByEmail(string email);
    void Add(User user);
}

public interface IMenuRepository
{
    void Add(Menu menu);
}
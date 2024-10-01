using BuberDinner.Application.Common.Contracts.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

internal sealed class MenuRepository : IMenuRepository
{

    private static readonly List<Menu> Menus = new();

    public void Add(Menu menu)
    {
        Menus.Add(menu);
    }
}
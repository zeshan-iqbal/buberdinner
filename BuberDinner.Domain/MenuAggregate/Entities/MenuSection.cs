using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _menuItems = new();
    private MenuSection(
        MenuSectionId id,
        string name,
        string description,
        List<MenuItem> menuItems)
        : base(id)
    {
        Name = name;
        Description = description;
        _menuItems = menuItems;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _menuItems.AsReadOnly();
   
    public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
    {
        return new(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}
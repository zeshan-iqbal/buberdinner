using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{

    private readonly List<MenuSection> _sections = new();
    private readonly List<MenuReviewId> _reviewIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    private Menu(
        MenuId id,
        string name,
        string description,
        HostId hostId,
        List<MenuSection> menuSections,
        AverageRating averageRating)
        : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = menuSections;
        AverageRating = averageRating;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviewIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedOn { get; private set; }
    public DateTime ModifiedOn { get; private set; }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection> sections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections,
            AverageRating.CreateNew(0));
    }
}
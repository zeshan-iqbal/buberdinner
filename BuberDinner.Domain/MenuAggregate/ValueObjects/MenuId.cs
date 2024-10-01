using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{

    private MenuId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
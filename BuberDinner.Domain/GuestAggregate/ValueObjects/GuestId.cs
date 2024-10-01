using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObject
{
    private GuestId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
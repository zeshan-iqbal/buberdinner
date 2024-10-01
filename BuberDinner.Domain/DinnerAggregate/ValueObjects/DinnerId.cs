using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
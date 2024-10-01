using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

public sealed class BillId : ValueObject
{

    private BillId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
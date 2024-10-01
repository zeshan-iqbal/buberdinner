using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
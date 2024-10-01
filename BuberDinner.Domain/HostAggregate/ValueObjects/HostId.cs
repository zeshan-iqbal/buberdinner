using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

public sealed class HostId : ValueObject
{

    private HostId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    /// <summary>
    /// value must be a guid.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static HostId Create(string value)
    {
        return new(Guid.Parse(value));
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
}
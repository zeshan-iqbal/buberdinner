using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Price: ValueObject
{
    public Price(string currency, double amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public string Currency { get; private set; }
    public double Amount { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
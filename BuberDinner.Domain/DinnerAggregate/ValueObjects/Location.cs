using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public Location(string name, string address, double latitue, double longitude)
    {
        Name = name;
        Address = address;
        Latitue = latitue;
        Longitude = longitude;
    }

    public string Name { get; private set; }
    public string Address { get; private set; }
    public double Latitue { get; private set; }
    public double Longitude { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Longitude;
        yield return Longitude;
    }
}
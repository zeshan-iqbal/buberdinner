namespace BuberDinner.Domain.Common.Models;

public interface IAuditable
{
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
}
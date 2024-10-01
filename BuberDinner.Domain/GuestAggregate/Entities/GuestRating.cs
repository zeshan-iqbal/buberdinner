using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities;

public sealed class GuestRating: Entity<RatingId>
{
    private GuestRating(
        RatingId id,
        HostId hostId,
        DinnerId dinnerId,
        float rating,
        DateTime createdOn,
        DateTime modifiedOn)
        : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedOn = createdOn;
        ModifiedOn = modifiedOn;
    }

    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public float Rating { get; private set; }
    
    public DateTime CreatedOn { get; private set; }
    public DateTime ModifiedOn { get; private set; }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        float rating,
        DateTime createdOn,
        DateTime modifiedOn)
    {
        return new(RatingId.CreateUnique(), hostId, dinnerId, rating, createdOn, modifiedOn);
    }

}
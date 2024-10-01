using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation 
    : Entity<ReservationId>, IAuditable
{
    private Reservation(
        ReservationId id,
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public int GuestCount { get; private set; }
    public string ReservationStatus { get; private set; } //TODO: PendingGuestConfirmation, Reserved, Cancelled
    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }
    public DateTime ArrivalDateTime { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Reservation Create(
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            createdDateTime,
            updatedDateTime);
    }
}
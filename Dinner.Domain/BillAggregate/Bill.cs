using Dinner.Domain.Bill.Entities;
using Dinner.Domain.Bill.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;
using Dinner.Domain.Host.ValueObjects;

namespace Dinner.Domain.Bill;

public class Bill : Entity<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId id,
        Price price,
        DinnerId dinnerId,
        HostId hostId,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime
    )
        : base(id)
    {
        Price = price;
        DinnerId = dinnerId;
        HostId = hostId;
        GuestId = guestId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill create(Price price, DinnerId dinnerId, HostId hostId, GuestId guestId) =>
        new(
            BillId.CreateUnique(),
            price,
            dinnerId,
            hostId,
            guestId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
}

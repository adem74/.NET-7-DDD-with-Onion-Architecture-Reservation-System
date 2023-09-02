using Dinner.Domain.Bill.ValueObjects;
using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Bill.Entities;

public sealed class Price : Entity<PriceId>
{
    private Price(PriceId priceId, double amount, string currency)
        : base(priceId)
    {
        Amount = amount;
        Currency = currency;
    }

    public double Amount { get; }
    public string Currency { get; }

    public static Price Create(double amount, string currency) =>
        new(PriceId.CreateUnique(), amount, currency);
}

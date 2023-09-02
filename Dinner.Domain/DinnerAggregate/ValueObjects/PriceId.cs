using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Dinner.ValueObjects;

public sealed class PriceId : ValueObject
{
    public Guid Value { get; }

    private PriceId(Guid value)
    {
        Value = value;
    }

    public static PriceId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

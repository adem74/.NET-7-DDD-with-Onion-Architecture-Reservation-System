using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Guest.ValueObjects;

public sealed class RateId : ValueObject
{
    public Guid Value { get; }

    private RateId(Guid value)
    {
        Value = value;
    }

    public static RateId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

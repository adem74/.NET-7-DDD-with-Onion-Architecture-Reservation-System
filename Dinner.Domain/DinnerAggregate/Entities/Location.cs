using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Dinner.Entities;

public sealed class Location : Entity<LocationId>
{
    private Location(
        LocationId locationId,
        string name,
        string address,
        double latitude,
        double longitude
    )
        : base(locationId)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public static Location Create(string name, string address, double latitude, double longitude) =>
        new(LocationId.CreateUnique(), name, address, latitude, longitude);
}

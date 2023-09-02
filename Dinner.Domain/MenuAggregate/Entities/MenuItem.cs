using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.ValueObjects;

namespace Dinner.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }

    public static MenuItem Create(string name, string description) =>
        new(MenuItemId.CreateUnique(), name, description);
        
#pragma warning disable CS8618
    private MenuItem() { }
#pragma warning restore CS8618
}
 
using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.ValueObjects;

namespace Dinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items;
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public string Name { get; }
    public string Description { get; }

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items
    )
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string name, string description, List<MenuItem> items) =>
        new(MenuSectionId.CreateUnique(), name, description, items);
        
#pragma warning disable CS8618
    private MenuSection() { }
#pragma warning restore CS8618
}

namespace Dinner.Contracts.Menus;

public record MenuCreateRequest(string Name, string Description, List<MenuSection> Sections);

public record MenuSection(string Name, string Description, List<MenuItem> Items);

public record MenuItem(string Name, string Description);

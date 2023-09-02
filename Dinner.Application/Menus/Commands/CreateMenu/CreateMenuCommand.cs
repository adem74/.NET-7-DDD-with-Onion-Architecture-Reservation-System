using Dinner.Domain.Menu;
using MediatR;

namespace Dinner.Application.Menus.Commands.CreateMenu;
public record CreateMenuCommand(string HostId,string Name, string Description, List<MenuSectionCommand> Sections): IRequest<Menu>;

public record MenuSectionCommand(string Name, string Description, List<MenuItemCommand> Items);

public record MenuItemCommand(string Name, string Description);

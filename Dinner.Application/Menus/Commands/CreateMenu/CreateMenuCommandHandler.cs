using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Menu;
using Dinner.Domain.Menu.Entities;
using MediatR;

namespace Dinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //create
        Menu menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.Create(request.HostId),
            sections: request.Sections.ConvertAll(
                s =>
                    MenuSection.Create(
                        s.Name,
                        s.Description,
                        s.Items.ConvertAll(m => MenuItem.Create(m.Name, m.Description))
                    )
            )
        );
        // persist
        _menuRepository.Add(menu);
        // return
        return menu ;
    }
}

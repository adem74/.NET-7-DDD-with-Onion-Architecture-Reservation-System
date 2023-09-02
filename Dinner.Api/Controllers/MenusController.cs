using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]  
public class MenusController : AuthorizedController
{
    public MenusController(ISender mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenuAsync(
        [FromBody] MenuCreateRequest request,
        string hostId
    )
    {
        var command = _mapper.Map<CreateMenuCommand>((request,hostId));
        var createMenuResponse =await _mediator.Send(command);
        return Ok(_mapper.Map<MenuResponse>(createMenuResponse));
    }
}
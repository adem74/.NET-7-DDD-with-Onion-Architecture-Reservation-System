

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers;

public class DinnersController : AuthorizedController
{
    public DinnersController(ISender mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    public IActionResult ListDinners(){
        return Ok(Array.Empty<string>());
    }
}
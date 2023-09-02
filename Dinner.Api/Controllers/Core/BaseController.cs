using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly ISender _mediator;
    protected readonly IMapper _mapper;

    public BaseController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}

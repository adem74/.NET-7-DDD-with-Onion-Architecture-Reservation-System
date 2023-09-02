using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Dinner.Api.Controllers;

[Authorize]
public class AuthorizedController : BaseController
{
    public AuthorizedController(ISender mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
}

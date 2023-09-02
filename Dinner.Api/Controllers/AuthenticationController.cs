using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Application.Services.Authentication;
using Dinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers;

 
[Route("auth")]
public class AuthenticationController : BaseController
{
    public AuthenticationController(ISender mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterCommand command = _mapper.Map<RegisterCommand>(request);

        AuthenticationResult result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        LoginQuery query = _mapper.Map<LoginQuery>(request);
        AuthenticationResult result = await _mediator.Send(query);

        return Ok(result);
    }
}

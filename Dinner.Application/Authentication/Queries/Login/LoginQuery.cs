using Dinner.Application.Services.Authentication; 
using MediatR;

namespace Dinner.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;

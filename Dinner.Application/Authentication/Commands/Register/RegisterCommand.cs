using Dinner.Application.Services.Authentication;
 using MediatR;

namespace Dinner.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<AuthenticationResult>;


using Dinner.Domain.User;

namespace Dinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);
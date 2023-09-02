using Dinner.Domain.User;

namespace Dinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{

    string GenerateToken(User user);
}
using Dinner.Application.Authentication.Queries.Login;
using FluentValidation;

namespace Dinner.Application.Authentication.Commands.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}

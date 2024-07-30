using MediatR;
using Microsoft.AspNetCore.Identity;
using Server.Domain.Entities;

namespace Server.Application.Features.Auth.SignUp;

internal sealed class SignUpCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<SignUpCommand>
{
    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = new()
        {
            UserName = request.UserName,
            Email = request.Email
        };

        await userManager.CreateAsync(user, request.Password);
    }
}

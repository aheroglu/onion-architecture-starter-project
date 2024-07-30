using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Application.Repositories;
using Server.Domain.Entities;

namespace Server.Application.Features.Auth.SignIn;

internal sealed class SignInCommandHandler(
    UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<SignInCommand, string>
{
    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager
             .Users
             .FirstOrDefaultAsync(p => p.UserName == request.UserName, cancellationToken);

        if (user is null) return "User not found!";

        bool isPasswordCorrect = await userManager
            .CheckPasswordAsync(user, request.Password);

        if (!isPasswordCorrect) return "Incorrect password!";

        string token = jwtProvider.GenerateToken(user);

        return token;
    }
}

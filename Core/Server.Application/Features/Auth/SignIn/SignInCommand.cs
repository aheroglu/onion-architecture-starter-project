using MediatR;

namespace Server.Application.Features.Auth.SignIn;

public sealed record SignInCommand(
    string UserName,
    string Password) : IRequest<string>;

using MediatR;

namespace Server.Application.Features.Auth.SignUp;

public sealed record SignUpCommand(
    string UserName,
    string Email,
    string Password) : IRequest;

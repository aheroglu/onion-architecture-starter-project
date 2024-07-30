using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Application.Features.Auth.SignIn;
using Server.Application.Features.Auth.SignUp;
using Server.WebAPI.Abstractions;

namespace Server.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInCommand command, CancellationToken cancellationToken)
        {
            var request = await mediator.Send(command, cancellationToken);
            if (request == "User not found!" || request == "Incorrect password!") return BadRequest(new { error = request });
            return Ok(new { token = request });
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Ok(new { message = "User created successfully" });
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.WebAPI.Abstractions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        public readonly IMediator mediator;

        protected ApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}

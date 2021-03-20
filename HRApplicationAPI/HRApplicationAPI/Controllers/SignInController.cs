using ApplicationCQRS.Queries.SignInQ;
using ApplicationDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplicationAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IMediator _mediator = default;
        public SignInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAuthDto value)
        {
            var command = new AuthenticateQuery() { User = value };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}

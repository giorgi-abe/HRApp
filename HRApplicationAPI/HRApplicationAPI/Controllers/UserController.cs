using ApplicationCQRS.Commands.UserC;
using ApplicationCQRS.Queries.UserQ;
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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator = default;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<UserDto> Get(string UserName)
        {
            var readById = new ReadUserByIdQuery() { Id = UserName };
            return await _mediator.Send(readById);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto UserDto,string Password)
        {
            if (UserDto == null || Password==null) { return BadRequest(); }

            var createUserCommand = new CreateUserCommand() {Password = Password,UserDto = UserDto };

            var result = await _mediator.Send(createUserCommand);
            if (result !=null)
                return Ok(result);

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string UserName, [FromBody] UserDto value)
        {
            if (value == null) { return BadRequest(); }

            var updateUserCommand = new UpdateUserCommand() { UserName = UserName, User = value };
            var result = await _mediator.Send(updateUserCommand);
            if (result)
                return Ok(value);

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string UserName)
        {
            var deleteUserCommand = new DeleteUserCommand() { UserName = UserName, };
            var result = await _mediator.Send(deleteUserCommand);
            if (result)
                return Ok();

            ModelState.AddModelError("error:500", "Server side exception :((");
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }
    }
}

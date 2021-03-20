using ApplicationDatabaseModels.Enums;
using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Commands.UserC
{
    public class CreateUserCommand : IRequest<string>
    {
        public UserDto UserDto { get; set; }
        public string Password { get; set; }
    }
}

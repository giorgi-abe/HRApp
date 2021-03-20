using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Commands.UserC
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public UserDto User { get; set; }
        public string UserName { get; set; }
    }
}

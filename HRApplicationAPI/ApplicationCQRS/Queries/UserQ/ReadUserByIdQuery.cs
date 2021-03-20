using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.UserQ
{
    public class ReadUserByIdQuery:IRequest<UserDto>
    {
        public string Id { get; set; }
    }
}

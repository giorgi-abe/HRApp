using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.SignInQ
{
    public class AuthenticateQuery : IRequest<string>
    {
        public UserAuthDto User { get; set; }
    }
}

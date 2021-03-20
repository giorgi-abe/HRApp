using ApplicationAuthentication.Abstraction;
using ApplicationCQRS.Queries.SignInQ;
using ApplicationDomainCore.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicationCQRS.Handlers.SignInHandlers
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateQuery, string>
    {
        private readonly IUserRepository _userRepository = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;


        public AuthenticateHandler(IUserRepository userRepository, IJwtAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
            _authenticationManager.SetUserRepo(userRepository);
        }

        public async Task<string> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var token = await _authenticationManager.AuthenticateAsync(request.User);
            if(token == null)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "Username or password is wrong" });
            }
            return token;
        }
    }
}

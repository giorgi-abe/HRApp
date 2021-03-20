using ApplicationAuthentication.Abstraction;
using ApplicationCQRS.Commands.UserC;
using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicationCQRS.Handlers.UserHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IMapper _mapper = default;
        private readonly IUserRepository _repository = default;
        private readonly UserManager<User> _userManager = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;
        public CreateUserHandler(IUserRepository Repository, IMapper mapper, UserManager<User> userManager, IJwtAuthenticationManager authenticationManager)
        {
            _mapper = mapper;
            _repository = Repository;
            _userManager = userManager;
            _authenticationManager = authenticationManager;
            _authenticationManager.SetUserRepo(Repository);
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dataName = await _userManager.FindByNameAsync(request.UserDto.UserName);
            var dataEmail = await _userManager.FindByEmailAsync(request.UserDto.Email);
            var dataIdNumber =( await _userManager.Users.ToListAsync()).FirstOrDefault(d => d.IdentityNumber == request.UserDto.IdentityNumber);
            if(dataEmail != null)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Email already exist" });
            }
            if (dataName != null)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Username already exist" });
            }
            if(dataIdNumber != default)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Identity number already exist" });
            }
            var user = _mapper.Map<User>(request.UserDto);
            var Registered = await _repository.RegisterAsync(user, request.Password);
            if(Registered) {
                var token = await _authenticationManager.AuthenticateAsync(new UserAuthDto { Username = user.UserName,Password = request.Password});
                return token;
            }
            return null;
        }
    }
}

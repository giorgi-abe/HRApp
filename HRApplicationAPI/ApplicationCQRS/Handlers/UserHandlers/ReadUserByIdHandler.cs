using ApplicationCQRS.Queries.UserQ;
using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserC
{
    public class ReadUserByIdHandler : IRequestHandler<ReadUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper = default;
        private readonly UserManager<User> _userManager = default;

        public ReadUserByIdHandler(UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDto> Handle(ReadUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _userManager.FindByIdAsync(request.Id);

            return _mapper.Map<UserDto>(data);
        }
    }
}

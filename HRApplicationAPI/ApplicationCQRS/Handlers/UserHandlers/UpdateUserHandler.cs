using ApplicationCQRS.Commands.UserC;
using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.UserC
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IUserRepository _repository = default;

        public UpdateUserHandler(IUserRepository Repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.UserName, _mapper.Map<User>(request.User));
            //gamarjoba.me var nuca da miyvars giorgi wohoooooooooooooooooo. me vwer kods
        }
    }
}

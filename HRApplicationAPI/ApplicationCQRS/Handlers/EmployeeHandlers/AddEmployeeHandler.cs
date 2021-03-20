using ApplicationCQRS.Commands.EmployeeC;
using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicationCQRS.Handlers.EmployeeHandlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, bool>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Employee> _repository = default;
        private readonly UserManager<User> _userManager = default;

        public AddEmployeeHandler(IRepository<Employee> Repository, UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _repository = Repository;
            _userManager = userManager;
        }

        public async Task<bool> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var dataEmail = (await _repository.ReadAsync()).FirstOrDefault(d=>d.Mail == request.EmployeeDto.Mail);
            var dataIdNumber = (await _repository.ReadAsync()).FirstOrDefault(d => d.IdentityNumber == request.EmployeeDto.IdentityNumber);
            if (dataEmail !=default)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Email already exist" });
            }
            if (dataIdNumber != default)
            {
                throw new HttpResponseException(new HttpResponseMessage { ReasonPhrase = "This Identity number already exist" });
            }
            var user = await _userManager.FindByNameAsync(request.Username);
            var employee = _mapper.Map<Employee>(request.EmployeeDto);
            employee.UserId = user.Id;
            return await _repository.CreateAsync(employee);
        }
    }
}

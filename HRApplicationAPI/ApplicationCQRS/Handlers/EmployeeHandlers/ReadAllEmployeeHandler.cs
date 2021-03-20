using ApplicationCQRS.Queries.EmployeeQ;
using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using ApplicationDomainCore.Abstraction;
using ApplicationDtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.EmployeeHandlers
{
    public class ReadAllEmployeeHandler : IRequestHandler<ReadAllEmployeeQuery,IEnumerable<EmployeeDto>>
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Employee> _repository = default;
        private readonly UserManager<User> _userManager = default;

        public ReadAllEmployeeHandler(IRepository<Employee> repository, UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(ReadAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            var data = await _repository.ReadAsync();
            var filterdata = data.Where(o => o.UserId == user.Id);
            return _mapper.Map<List<EmployeeDto>>(filterdata);
        }
    }
}

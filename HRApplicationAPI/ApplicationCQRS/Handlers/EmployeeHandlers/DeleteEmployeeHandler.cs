using ApplicationCQRS.Commands.EmployeeC;
using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCQRS.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IRepository<Employee> _repository = default;

        public DeleteEmployeeHandler(IRepository<Employee> Repository)
        {
            _repository = Repository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}

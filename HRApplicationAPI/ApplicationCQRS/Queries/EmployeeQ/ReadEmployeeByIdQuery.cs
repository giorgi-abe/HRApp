using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.EmployeeQ
{
    public class ReadEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
}

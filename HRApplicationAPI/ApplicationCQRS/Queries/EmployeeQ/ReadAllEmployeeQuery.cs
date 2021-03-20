using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Queries.EmployeeQ
{
    public class ReadAllEmployeeQuery:IRequest<IEnumerable<EmployeeDto>>
    {
        public string Username { get; set; }
    }
}

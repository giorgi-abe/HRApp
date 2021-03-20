using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Commands.EmployeeC
{
    public class AddEmployeeCommand : IRequest<bool>
    {
        public EmployeeDto EmployeeDto { get; set; }
        public string Username { get; set; }

    }
}

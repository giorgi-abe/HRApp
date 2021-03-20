using ApplicationDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCQRS.Commands.EmployeeC
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public EmployeeDto Employee { get; set; }
        public int Id { get; set; }
    }
}

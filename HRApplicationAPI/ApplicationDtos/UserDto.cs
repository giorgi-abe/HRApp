using ApplicationDatabaseModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<EmployeeDto> Employees { get; set; }

    }
}

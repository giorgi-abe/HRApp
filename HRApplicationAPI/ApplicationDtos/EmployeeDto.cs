using ApplicationDatabaseModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        public StatusType Status { get; set; }
        public string Position { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Mobile { get; set; }
    }
}

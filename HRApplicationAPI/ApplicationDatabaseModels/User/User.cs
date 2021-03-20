using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationDatabaseModels.Enums;
using Microsoft.AspNetCore.Identity;

namespace ApplicationDatabaseModels.User
{
    public class User : IdentityUser
    {
        [StringLength(11)]
        public string IdentityNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }
        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

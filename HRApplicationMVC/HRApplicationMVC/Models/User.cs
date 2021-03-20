using ApplicationDatabaseModels;
using ApplicationDatabaseModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRApplicationMVC.Models
{
    public class User
    {
        public string Id { get; set; }
        [MinLength(11, ErrorMessage = "Length must be 11")]
        [MaxLength(11)]
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }
        [MinLength(6, ErrorMessage = "Length Must be more than 5")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

    }

}

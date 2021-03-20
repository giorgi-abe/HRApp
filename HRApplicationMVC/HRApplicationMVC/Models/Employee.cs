using ApplicationDatabaseModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRApplicationMVC.Models
{
    public class Employee 
    {
        public int Id { get; set; }
        [MinLength(11,ErrorMessage ="Length must be 11")]
        [MaxLength(11)]
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public StatusType Status { get; set; }
        [Required]
        public string Position { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Mobile { get; set; }
    }
}

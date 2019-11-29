using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementApp.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

        [Required]
        public Boolean IsConfirmed { get; set; }


    }
}
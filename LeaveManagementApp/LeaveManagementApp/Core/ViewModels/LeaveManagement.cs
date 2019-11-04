using LeaveManagementApp.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementApp.Core.ViewModels
{
    public class LeaveManagement
    {
        public class LeaveType
        {
            [Required]
            [Display(Name="Id")]
            public int Id { get; set; }

            [Required]
            [Display(Name ="Leave Type")]
            public string Leave_Type { get; set; }
        }

        public class EmployeeLeaveCount
        {
            [Required]
            [Display(Name ="Id")]
            public int Id { get; set; }

            [Required]
            [Display(Name ="Employee Name")]
            public Employee Name { get; set; }

            [Required]
            [Display(Name ="Year")]
            public DateTime Year { get; set; }

            [Required]
            [Display(Name ="Leave Type")]
            public LeaveType LeaveType { get; set; }

            [Required]
            [Display(Name ="Total Count")]
            public int AvailableCount { get; set; }

            [Required]
            [Display(Name = "Remain Count")]
            public int RemainCount { get; set; }

        }
    }
}
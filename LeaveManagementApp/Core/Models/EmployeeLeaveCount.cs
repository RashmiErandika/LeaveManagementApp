using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementApp.Core.Models
{
    public class EmployeeLeaveCount
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public Leave Leave { get; set; }

        public int Year { get; set; }

        public int EntitleCount { get; set; } 

        public int RemainCount { get; set; }



    }
}
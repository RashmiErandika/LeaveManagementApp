using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementApp.Core.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        [Required]
        public int Leave_Type { get; set; }

        [ForeignKey("Leave_Type")]
        public Leave Leave { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

    }
}
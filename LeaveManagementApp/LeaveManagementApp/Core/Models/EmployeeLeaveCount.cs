using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaveManagementApp.Core.Models
{
    public class EmployeeLeaveCount : BaseModel
    {
        public int Id { get; set; }
        public Employee EmployeeName { get; set; }
        public DateTime Year { get; set; }
        public int TotalLeaveCount { get; set; }
        public int RemainLeaveCount { get; set; }
        
        
    }
}
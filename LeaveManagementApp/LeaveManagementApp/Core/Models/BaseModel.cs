using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementApp.Core.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
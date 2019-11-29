using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeaveManagementApp.Models;

namespace LeaveManagementApp.Persistence.Repositories
{
    public class AdminRepository : BaseRepository<AdminRepository> 
    {
        public AdminRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
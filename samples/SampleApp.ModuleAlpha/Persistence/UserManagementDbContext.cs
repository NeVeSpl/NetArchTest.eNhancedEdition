using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleApp.ModuleAlpha.Domain;

namespace SampleApp.ModuleAlpha.Persistence
{
    public class UserManagementDbContext
    {
        public DbSet<User> Users { get; private set; }
    }
}

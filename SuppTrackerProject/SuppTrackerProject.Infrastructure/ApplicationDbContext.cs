using SuppTrackerProject.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : this(ConnectionInfo.CONNECTIONSTRING)
        { 
        }
        public ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { 
        }

    }
}

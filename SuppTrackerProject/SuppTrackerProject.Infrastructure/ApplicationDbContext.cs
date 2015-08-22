using SuppTrackerProject.Domain.Entities;
using SuppTrackerProject.Domain.Identity;
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

        public IDbSet<User> Users { get; set; }
        public IDbSet<Supplement> Supplements { get; set; }
        public IDbSet<SupplementUser> SupplementUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
        }
    }
}

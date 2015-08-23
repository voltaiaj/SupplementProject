using SuppTrackerProject.Domain.Identity;
using SuppTrackerProject.Domain.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuppTrackerProject.Infrastructure.Repositories
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        internal RoleRepository(ApplicationDbContext context)
            : base(context)
        { 
        }

        public IRepository<Role> Repo
        {
            get { return this; }
        }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}

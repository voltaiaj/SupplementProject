using SuppTrackerProject.Domain.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace SuppTrackerProject.Domain.Repositories
{
    public interface IRoleRepository
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
        IRepository<Role> Repo { get; }
    }
}

using SuppTrackerProject.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace SuppTrackerProject.Domain
{
    public interface IUnitOfWork
    {
        void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IExternalLoginRepository ExternalLoginRepository { get; }
    }
}

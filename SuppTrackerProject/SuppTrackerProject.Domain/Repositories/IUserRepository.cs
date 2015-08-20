using SuppTrackerProject.Domain.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace SuppTrackerProject.Domain.Repositories
{
    public interface IUserRepository
    {
        User FindByEmail(string usernameEmail);
        Task<User> FindByEmailAsync(string usernameEmail);
        Task<User> FindByEmailAsync(CancellationToken cancellationToken, string usernameEmail);
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username);
        IRepository<User> Repo { get; }
    }
}

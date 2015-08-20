using SuppTrackerProject.Domain.Identity;
using SuppTrackerProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Infrastructure.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(ApplicationDbContext context)
            : base(context)
        { 
        }

        //Property Provides access to base Repository<TEntity> members
        public IRepository<User> Repo
        {
            get { return this; }
        }

        #region Universal UserMethods
        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }

        public User FindByEmail(string usernameEmail)
        {
            return Set.FirstOrDefault(x => x.UserName == usernameEmail);
        }

        public Task<User> FindByEmailAsync(string usernameEmail)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == usernameEmail);
        }

        public Task<User> FindByEmailAsync(System.Threading.CancellationToken cancellationToken, string usernameEmail)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == usernameEmail, cancellationToken);
        }
        #endregion
    }
}

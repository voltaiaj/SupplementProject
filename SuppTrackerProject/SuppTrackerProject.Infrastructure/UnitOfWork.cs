using SuppTrackerProject.Domain.Repositories;
using SuppTrackerProject.Infrastructure;
using SuppTrackerProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuppTrackerProject.Infrastructure
{
    public class UnitOfWork
    {
        #region Fields
        public readonly ApplicationDbContext _context;
        private IUserRepository _userRepository;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }
        public UnitOfWork(string connectionString) : base(){ }
        #endregion

        #region UnitOfWork Members
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion 

        #region IDisposable Members
        public void Dispose()
        {
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}

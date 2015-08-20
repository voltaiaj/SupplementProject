using SuppTrackerProject.Domain.Repositories;
using SuppTrackerProject.Infrastructure;
using SuppTrackerProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Services
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
        #endregion 
    }
}

﻿using SuppTrackerProject.Domain;
using SuppTrackerProject.Domain.Entities;
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
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        public readonly ApplicationDbContext _context;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IExternalLoginRepository _externalLoginRepository;
        private IRepository<Supplement> _supplementRepository;
        private IRepository<SupplementUser> _supplementUserRepository;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }
        public UnitOfWork(string connectionString) : base(){ }
        #endregion

        #region UnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }
        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }
        public IRepository<Supplement> SupplementRepository
        {
            get { return _supplementRepository ?? (_supplementRepository = new Repository<Supplement>(_context)); }
        }
        public IRepository<SupplementUser> SupplementUserRepository
        {
            get { return _supplementUserRepository ?? (_supplementUserRepository = new Repository<SupplementUser>(_context)); }
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
            _externalLoginRepository = null;
            _roleRepository = null;
            _supplementRepository = null;
            _supplementUserRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}

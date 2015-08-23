using SuppTrackerProject.Domain;
using SuppTrackerProject.Domain.Entities;
using SuppTrackerProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Services.Data
{
    public class SupplementUserService
    {
        private IUnitOfWork _unitOfWork;

        public SupplementUserService()
        {
            _unitOfWork = new UnitOfWork();
        }

        #region Add Methods
        //ADD SupplementUser
        public void AddSupplementUser(SupplementUser supplementUser)
        {
            _unitOfWork.SupplementUserRepository.Add(supplementUser);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region Get Methods
        //GET all SupplementUsers
        public IList<SupplementUser> GetAllSupplementUsers()
        {
            return _unitOfWork.SupplementUserRepository.GetAll().ToList();
        }
        //GET SupplementUser by Id
        public SupplementUser GetSupplementUserById(int id)
        {
            return _unitOfWork.SupplementUserRepository.Query().Where(x => x.SuppUserId == id).FirstOrDefault();
        }
        //GET all SupplementUsers by UserId
        public IList<SupplementUser> GetSupplementUsersByUserId(Guid userId)
        {
            return _unitOfWork.SupplementUserRepository.Query().Where(x => x.UserId == userId).ToList();
        }
        //GET all SupplementUsers by SupplementId
        public IList<SupplementUser> GetSupplementUsersBySupplementId(int supplementId)
        {
            return _unitOfWork.SupplementUserRepository.Query().Where(x => x.SupplementId == supplementId).ToList();
        }
        #endregion

        #region Update Methods
        //UPDATE SupplementUser
        public void UpdateSupplementUser(SupplementUser supplementUser)
        {
            _unitOfWork.SupplementUserRepository.Update(supplementUser);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region Delete Methods
        //DELETE SupplementUser
        public void DeleteSupplementUser(SupplementUser supplementUser)
        {
            _unitOfWork.SupplementUserRepository.Remove(supplementUser);
            _unitOfWork.SaveChanges();
        }
        #endregion
    }
}

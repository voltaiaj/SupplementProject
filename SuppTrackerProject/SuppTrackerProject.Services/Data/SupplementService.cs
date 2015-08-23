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
    public class SupplementService
    {
        private IUnitOfWork _unitOfWork;

        public SupplementService()
        {
            _unitOfWork = new UnitOfWork();
        }

        #region ADD Methods
        //ADD Supplement
        public void AddSupplement(Supplement supplement)
        {
            _unitOfWork.SupplementRepository.Add(supplement);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region GET Methods
        //GET All Supplements
        public IList<Supplement> GetAllSupplements()
        {
            return _unitOfWork.SupplementRepository.GetAll();
        }
        //GET All Supplements by Manufacturer
        public IList<Supplement> GetSupplementsByManufacturer(string manufacturer)
        {
            return _unitOfWork.SupplementRepository.GetAll().Where(x => x.Manufacturer == manufacturer).ToList();
        }
        #endregion

        #region Update Methods
        //UPDATE Supplement
        public void UpdateSupplement(Supplement supplement)
        {
            _unitOfWork.SupplementRepository.Update(supplement);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region Delete Methods
        //DELETE Supplement
        public void DeleteSupplement(Supplement supplement)
        {
            _unitOfWork.SupplementRepository.Remove(supplement);
            _unitOfWork.SaveChanges();
        }
        #endregion
    }
}

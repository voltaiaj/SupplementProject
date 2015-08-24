using SuppTrackerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Services.Data
{
    public class DataServices
    {
        private Supplement _supplement;
        private SupplementUser _supplementUser;
        private SupplementService _supplementService;
        private SupplementUserService _supplementUserService;

        #region Properties
        public Supplement Supplement
        {
            get { return _supplement ?? new Supplement(); }
        }
        public SupplementUser SupplementUser
        {
            get { return _supplementUser ?? new SupplementUser(); }
        }
        public SupplementService SupplementService 
        {
            get { return _supplementService ?? new SupplementService(); }
        }
        public SupplementUserService SupplementUserService
        {
            get { return _supplementUserService ?? new SupplementUserService(); }
        }
        #endregion
    }
}

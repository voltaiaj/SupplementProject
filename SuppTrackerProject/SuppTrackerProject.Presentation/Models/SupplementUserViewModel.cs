using SuppTrackerProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuppTrackerProject.Presentation.Models
{
    public class SupplementUserViewModel
    {
        public ICollection<SupplementUser> SupplementUser { get; set; }
    }
}
using SuppTrackerProject.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Domain.Entities
{
    public class SupplementUser
    {
        [Key]
        public int SuppUserId { get; set; }
        [ForeignKey("User")]
        [InverseProperty("Supplements")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Supplement")]
        [InverseProperty("Users")]
        public int SupplementId { get; set; }
        public virtual Supplement Supplement { get; set; }

        public double ServingsPerDay { get; set; }
        public double EmptyWeight { get; set; }
        public double PartialWeight { get; set; }
        public double FullWeight { get; set; }
        public double NumberOfNew { get; set; }
    }
}

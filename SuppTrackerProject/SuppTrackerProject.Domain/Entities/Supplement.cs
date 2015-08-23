using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuppTrackerProject.Domain.Entities
{
    public class Supplement
    {
        [Key]
        public int SupplementId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public int Servings { get; set; }

        public virtual  ICollection<SupplementUser> Users { get; set; }

    }
}

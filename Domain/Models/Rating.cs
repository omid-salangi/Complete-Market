using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        //relations
        public ICollection<RatingDetail> RatingDetails { get; set; }
        public IdentityUserChange IdentityUserChange { get; set; }
    }
}

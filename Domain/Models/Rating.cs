using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int RatingDetail { get; set; }
        public ICollection<RatingDetail> RatingDetails { get; set; }
        public IdentityUserChange IdentityUserChange { get; set; }
    }
}

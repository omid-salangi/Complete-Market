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
        public int RatingNumber { get; set; }
        [ForeignKey("IdentityUserChange")]
        public string IdentityUserChangeId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public IdentityUserChange IdentityUserChange { get; set; }
    }
}

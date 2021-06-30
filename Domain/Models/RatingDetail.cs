using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RatingDetail
    {
        [Key] public int Id { get; set; }

        public int RatingNumber { get; set; }

        //relations
        public int ProductId { get; set; }
        [ForeignKey("ProductId")] public Product Product { get; set; }

        public int RatingId { get; set; }
        [ForeignKey("RatingId")]
        public Rating Rating { get; set; }
    }
}

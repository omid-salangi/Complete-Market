using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public bool IsFinally { get; set; }


        // relations
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUserChange IdentityUserChange { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsShow { get; set; }

        //relations
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string IdentityUserChangeId { get; set; }
        [ForeignKey("IdentityUserChangeId")]
        public IdentityUserChange IdentityUserChange { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
     public class FavoriteList
    {
        [Key]           
        public int FavoriteListId { get; set; }

        public int Count { get; set; }
        [ForeignKey("IdentityUserChange")]
        public int IdentityUserChangeId { get; set; } 

        //relations
        public IdentityUserChange IdentityUserChange { get; set; }
        public ICollection<FavoriteToProduct> FavoriteToProducts { get; set; }

    }
}
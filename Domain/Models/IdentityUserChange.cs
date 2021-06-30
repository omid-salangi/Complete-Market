using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class IdentityUserChange : IdentityUser
    {
        public string ImgUrl { get; set; }
        //relations
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int FavoriteListId { get; set; }
        [ForeignKey("FavoriteListId")]
        public FavoriteList FavoriteList { get; set; }
    }
}

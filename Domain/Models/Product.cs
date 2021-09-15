using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Name  { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int VisitCount { get; set; }
        public int BuyCount { get; set; }
        

        // relations
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item Item { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<FavoriteToProduct> FavoriteToProducts { get; set; }
        
    }
}

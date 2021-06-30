using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ImgAddress { get; set; }
        public string Name  { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int VisitCount { get; set; }
        public int BuyCount { get; set; }
        

        // relations
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}

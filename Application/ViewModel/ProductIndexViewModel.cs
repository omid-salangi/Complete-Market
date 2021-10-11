using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ProductIndexViewModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; }

    }
}

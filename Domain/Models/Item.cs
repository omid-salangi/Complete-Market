using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        //relations
        public Product Product { get; set; }

    }
}

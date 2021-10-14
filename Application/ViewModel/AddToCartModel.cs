using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.ViewModel
{
   public class AddToCartModel
    {
        
        public int productid { get; set; }
        public int count { get; set; }
    }
}

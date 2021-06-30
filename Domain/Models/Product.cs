﻿using System;
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

    }
}
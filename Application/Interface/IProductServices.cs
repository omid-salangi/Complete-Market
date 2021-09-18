﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Interface
{
    public interface IProductServices
    {
        Task<IList<ProductViewModel>> GetProducts();
        Task CreateProduct(CreateProductViewModel model);
    }
}
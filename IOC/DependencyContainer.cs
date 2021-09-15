﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Domain.Interface;

namespace IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //application layer
            service.AddScoped<IMessageSender, MessageSender>();
            service.AddScoped<IProductServices, ProductServices>();
            //data layer
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IFavoriteListRepository, FavoriteRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IRatingRepository, RatingRepository>();

        }
    }
}

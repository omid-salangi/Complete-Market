using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //application layer

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Application.Services.Security.Default;
using Domain.Interface;
using Microsoft.AspNetCore.Authorization;

namespace IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //application layer
            service.AddScoped<IMessageSender, MessageSender>();
            service.AddScoped<IProductServices, ProductServices>();
            service.AddScoped<IImageServices,ImageServices>();
            service.AddScoped<IRoleManagerServices, RoleManagerServices>();
            service.AddScoped<IUserManagerServices,UserManagerServices>();
            service.AddScoped<IOrderServices, OrderServices>();
            //set authorization handler
            service.AddSingleton<IAuthorizationHandler, ClaimHandler>();
            //
            //data layer
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<IFavoriteListRepository, FavoriteRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IRatingRepository, RatingRepository>();
            service.AddScoped<IItemRepository, ItemRepository>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using IOC;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using MVC.Controllers;

namespace MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MarketDbConnection"));
            });

            services.AddAuthentication().AddGoogle(options =>
                {
                    options.ClientId = Configuration["googleapi:clientid"];
                    options.ClientSecret = Configuration["googleapi:clientsecret"];
                }
            );
            services.AddIdentity<IdentityUserChange, IdentityRole>(options =>// we can add new setting in identity
                {
                    options.User.RequireUniqueEmail = true; // each user should have unique email address
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+*/!#$%^&*(){}[]\\?\"':;,";
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // lock account after 5 times wrong password input



                }).AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<TranslatePersian.TranslatePersian>();
            services.AddAuthorization(option =>
            {
                option.AddPolicy("ProductListPolicy", policy => // ProductlistPolicy is a name that you select 
                {
                    policy.RequireClaim(ClaimTypeStore.IsEmailConfirmed,true.ToString());
                   
                });
                option.AddPolicy("ClaimOrRole", policy =>
                    policy.RequireAssertion(context => context.User.HasClaim("ProductList", true.ToString()) // use reqiureassertion to add many roles and claims
                                                                                                             || context.User.IsInRole("Admin"))); /// straight way
                option.AddPolicy("ClaimRequirement", policy =>
                    policy.Requirements.Add(new ClaimRequirement(ClaimTypeStore.IsEmailConfirmed, true.ToString()))); /// for handler  and we can use empty class instead claimrequirements class and do every thing in handler 
            });


            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(5);

                options.LoginPath = "/Accounts/Login";
                options.AccessDeniedPath = "/Accounts/AccessDenied";
                options.SlidingExpiration = true;
            });


            services.AddControllersWithViews();
            services.AddRazorPages();



           // SetClaims(services); //// set claims ///error for addauthorization
            RegisterServices(services);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseStatusCodePages(async Context =>
            //{
            //    var response = Context.HttpContext.Response;
            //    if (response.StatusCode ==(int) HttpStatusCode.Unauthorized || response.StatusCode == (int)HttpStatusCode.Forbidden)
            //    {
            //        response.Redirect("/Accounts/Login");
            //    }
            //});
        }

        public static void RegisterServices(IServiceCollection service)
        {
            DependencyContainer.RegisterServices(service);
        }

    }
}

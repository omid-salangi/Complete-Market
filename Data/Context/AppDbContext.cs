﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUserChange> // for changing identity relations
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<FavoriteList> FavoriteLists { get; set; }
        public DbSet<FavoriteToProduct> FavoriteToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // important for identity change

            modelBuilder.Entity<CategoryToProduct>().HasKey(p => new { p.ProductId, p.CategoryId }); // many to many 
            modelBuilder.Entity<FavoriteToProduct>().HasKey(p => new { p.ProductId, p.FavoriteListId }); // many to many

            modelBuilder.Entity<Item>().Property(p => p.Price).HasColumnType("Money");  // for price 
            //modelBuilder.Entity<OrderDetail>().Property(p => p.Price).HasColumnType("Money");
        }
    }
}

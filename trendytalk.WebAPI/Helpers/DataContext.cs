using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Entities;
using System;
using JetBrains.Annotations;
using trendytalk.WebAPI.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<AdminPanel> adminpanel { get; set; }
        public DbSet<NewsChannel> newschannels { get; set; }        
    }
}
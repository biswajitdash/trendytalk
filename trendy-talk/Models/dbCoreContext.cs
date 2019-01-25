using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace trendytalk.Models
{
    public partial class dbCoreContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<CategoryModel> Category { get; set; }
        public virtual DbSet<CountryModel> Country { get; set; }
        public virtual DbSet<AdminPanelModel> AdminPanel { get; set; }
        public virtual DbSet<NewsChannels> NewsChannel { get; set; }

        public dbCoreContext(DbContextOptions<dbCoreContext> options) :
             base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(@"Server=DESKTOP-80DEJMQ;Database=dbCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<CategoryModel>(entity =>
            {
                entity.Property(e => e.CategoryId).HasMaxLength(50);
                entity.Property(e => e.CategoryName).HasMaxLength(250);
                entity.Property(e => e.IsActive).HasMaxLength(1);
                entity.Property(e => e.CreatedOn).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn).HasMaxLength(50);
            });

            modelBuilder.Entity<CountryModel>(entity =>
            {
                entity.Property(e => e.CountryId).HasMaxLength(50);
                entity.Property(e => e.CountryName).HasMaxLength(250);
                entity.Property(e => e.IsActive).HasMaxLength(1);
                entity.Property(e => e.CreatedOn).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn).HasMaxLength(50);
            });

            modelBuilder.Entity<AdminPanelModel>(entity =>
            {
                entity.Property(e => e.AdminPanelId).HasMaxLength(50);
                entity.Property(e => e.CategoryId).HasMaxLength(50);
                entity.Property(e => e.CountryId).HasMaxLength(50);
                entity.Property(e => e.Topic).HasMaxLength(500);
                entity.Property(e => e.HyperLink).HasMaxLength(500);
                entity.Property(e => e.NewsChannelId).HasMaxLength(50);
                entity.Property(e => e.IsActive).HasMaxLength(1);
                entity.Property(e => e.CreatedOn).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn).HasMaxLength(50);
            });

            modelBuilder.Entity<NewsChannels>(entity =>
            {
                entity.Property(e => e.NewsChannelId).HasMaxLength(50);
                entity.Property(e => e.NewsChannelName).HasMaxLength(250);
                entity.Property(e => e.IsActive).HasMaxLength(1);
                entity.Property(e => e.CreatedOn).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn).HasMaxLength(50);
            });
        }
    }
}

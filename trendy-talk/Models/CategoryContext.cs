using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trendytalk.Models
{
    public class CategoryContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public CategoryContext(DbContextOptions<CategoryContext> options) :
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
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasMaxLength(50);
                entity.Property(e => e.CategoryName).HasMaxLength(250);
                entity.Property(e => e.IsActive).HasMaxLength(1);
                entity.Property(e => e.CreatedOn).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn).HasMaxLength(50);
            });
        }
    }
}

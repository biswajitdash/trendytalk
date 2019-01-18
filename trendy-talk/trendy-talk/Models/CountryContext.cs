using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trendytalk.Models
{
    public class CountryContext : DbContext
    {
        public virtual DbSet<Country> Country { get; set; }
        public CountryContext(DbContextOptions<CountryContext> options) :
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
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasMaxLength(50);
                entity.Property(e => e.CountryName).HasMaxLength(250);
                entity.Property(e => e.IsActive).HasMaxLength(1);
                entity.Property(e => e.CreatedOn).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn).HasMaxLength(50);
            });
        }
    }
}

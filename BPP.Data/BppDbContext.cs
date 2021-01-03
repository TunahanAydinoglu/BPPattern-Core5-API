using BPP.Core.Models;
using BPP.Data.Confıguratıons;
using BPP.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Data
{
    public class BppDbContext : DbContext
    {
        public BppDbContext(DbContextOptions<BppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2, 3 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2, 3 }));

        }


    }
}

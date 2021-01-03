using BPP.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Data.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Trampet", Price = 120.50m, Stock = 20, IsActive = true, CategoryId = _ids[1] },
                new Product { Id = 2, Name = "Klasık Gıtar", Price = 220.50m, Stock = 15, IsActive = false, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Elektro Gıtar", Price = 137.53m, Stock = 10, IsActive = true, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Baglama", Price = 99.50m, Stock = 20, IsActive = true, CategoryId = _ids[0] },
                new Product { Id = 5, Name = "Blok Flut", Price = 15.50m, Stock = 20, IsActive = true, CategoryId = _ids[2] }
                );
        }
    }
}

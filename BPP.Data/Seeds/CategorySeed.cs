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
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category { Id = _ids[0], Name = "Telliler", IsActive = true },
                    new Category { Id = _ids[1], Name = "Vurmalilar", IsActive = true },
                    new Category { Id = _ids[2], Name = "Uflemeliler", IsActive = true }
                );
        }
    }
}

using BPP.Core.Models;
using BPP.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private BppDbContext _bppDbContext { get => _context as BppDbContext; }
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _bppDbContext.Categories.Include(c => c.Products).SingleOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}

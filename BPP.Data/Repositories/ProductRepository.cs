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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private BppDbContext _bppDbContext { get => _context as BppDbContext; }
        public ProductRepository(BppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetProductWidhtCategoryNameAsync(int productId)
        {
            var product = await _bppDbContext.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == productId);
            return product;
        }
    }
}

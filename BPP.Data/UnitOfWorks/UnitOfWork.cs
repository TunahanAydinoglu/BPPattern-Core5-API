using BPP.Core.Repositories;
using BPP.Core.UnitOfWorks;
using BPP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        public UnitOfWork(BppDbContext bppDbContext)
        {
            _context = bppDbContext;
        }
        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

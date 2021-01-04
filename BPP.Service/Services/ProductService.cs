using BPP.Core.Models;
using BPP.Core.Repositories;
using BPP.Core.Services;
using BPP.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {

        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetProductsWithCategoryNameAsync(int productId)
        {
            return await _unitOfWork.Products.GetProductWidhtCategoryNameAsync(productId);
        }
    }
}

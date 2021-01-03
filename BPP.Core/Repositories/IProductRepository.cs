using BPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Core.Repositories
{
    public interface IProductRepository :IRepository<Product>
    {
        Task<Product> GetProductWidhtCategoryNameAsync(int productId);
    }
}

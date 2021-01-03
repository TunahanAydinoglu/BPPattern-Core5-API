using BPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Core.Services
{
    public interface IProductService :IService<Product>
    {
        //bool ControlIsActive(Product product);
        Task<Product> GetProductsWithCategoryNameAsync(int productId);
    }
}

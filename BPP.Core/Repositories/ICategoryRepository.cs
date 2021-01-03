using BPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Core.Repositories
{
    public interface ICategoryRepository :IRepository<Category>
    {
        Task<Category> GetProductsByCategoryIdAsync(int categoryId);

    }
}

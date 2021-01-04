using BPP.Core.Models;
using BPP.Core.Repositories;
using BPP.Core.Services;
using BPP.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPP.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetProductsByCategoryIdAsync(categoryId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPP.WebAPI.Dtos
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}

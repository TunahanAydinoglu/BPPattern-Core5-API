using AutoMapper;
using BPP.Core.Models;
using BPP.Core.Services;
using BPP.WebAPI.Dtos;
using BPP.WebAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]//interface icerdigi icin startupda
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetProductsWithCategoryNameAsync(int id)
        {
            var product = await _productService.GetProductsWithCategoryNameAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAync(id);
            _productService.Remove(product);
            return NoContent();
        }

    }
}

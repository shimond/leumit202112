using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project_intro.Contracts;
using project_intro.Exceptions;
using project_intro.Filters;
using project_intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(ICourseApiExceptionFilter))]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(
            IMapper mapper,
            IProductService productService, ILogger<ProductsController> logger)
        {
            _mapper = mapper;
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var result = await _productService.GetAllProducts();
            var dtos = result.Select(x => _mapper.Map<ProductDTO>(x)).ToList();
            return Ok(dtos);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ProductDTO>>> Search(string term)
        {
            var result = await _productService.SearchProduct(term);
            var dtos = result.Select(x => _mapper.Map<ProductDTO>(x)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(_mapper.Map<ProductDTO>(result));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddNewProduct(ProductDTO p)
        {
            var result = await _productService.AddNewProduct(_mapper.Map<Product>(p));
            var res = _mapper.Map<ProductDTO>(result);
            return Created($"/api/products/{res.Id}", res);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        public async Task<ActionResult> UpdateProduct(int id, ProductDTO p)
        {
            var productToUpdate = p with { Id = id };
            var result = await _productService.UpdateProduct(_mapper.Map<Product>(p));
            return Ok(_mapper.Map<ProductDTO> (result));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDTO))]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(_mapper.Map<ProductDTO>(result));
        }

    }
}




//if (!ModelState.IsValid)
//{
//    return BadRequest(ModelState);
//}

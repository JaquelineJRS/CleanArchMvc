using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetListAsync()
        {
            var productsList = await _productService.GetProducts();
            if (productsList == null) return NotFound("Products not found.");
            return Ok(productsList);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetByIdAsync(int? id)
        {
            var product = await _productService.GetById(id);
            if (product == null) return NotFound("Product not found.");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest();
            await _productService.Add(productDTO);
            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync(int? id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id) return BadRequest();
            if (productDTO == null) return BadRequest();

            await _productService.Update(productDTO);
            return Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int? id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound("Product not found.");

            await _productService.Remove(id);
            return Ok(product);
        }
    }
}

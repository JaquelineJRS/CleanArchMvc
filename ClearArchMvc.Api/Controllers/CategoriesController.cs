using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAsyncList()
        {
            var categoryList = await _categoryService.GetCategories();
            if (categoryList == null) return NotFound("Categories not found.");
            return Ok(categoryList);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetAsyncById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null) return NotFound("Category not found.");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) return BadRequest("Incorrect data.");

            await _categoryService.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id) return BadRequest();
            if (categoryDTO == null) return BadRequest();

            await _categoryService.Update(categoryDTO);
            return Ok(categoryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(CategoryDTO categoryDTO, int? id)
        {
            await _categoryService.GetById(id);
            if (categoryDTO == null) NotFound("Product not found.");

            await _categoryService.Remove(id);
            return Ok(categoryDTO);
        }
    }
}

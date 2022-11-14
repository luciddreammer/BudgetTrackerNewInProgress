using BudgetTracker.Models;
using BudgetTracker.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category categorOOOOOyOL)
        {
            await _categoryRepository.AddNewCategory(category);
            return Ok();
        }

        [HttpPut("ModifyCategory/{oldCategoryId:int}")]
        public async Task<IActionResult> ModifyCategory(int oldCategoryId, Category newCategory)
        {
            await _categoryRepository.ModifyCategory(oldCategoryId, newCategory);
            return Ok();
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok();
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryRepository.GetAllCategories());
        }
    }
}

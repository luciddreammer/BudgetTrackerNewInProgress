using BudgetTracker.Data.Models;
using BudgetTracker.Models;
using BudgetTracker.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        [HttpPost("AddSubCategory")]
        public async Task<IActionResult> AddSubCategory(SubCategory subCategory)
        {
            await _subCategoryRepository.AddNewSubCategory(subCategory);
            return Ok();
        }

        [HttpPut("ModifySubCategory/{oldSubCategoryId:int}")]
        public async Task<IActionResult> ModifySubCategory(int oldSubCategoryId, SubCategory newSubCategory)
        {
            await _subCategoryRepository.ModifySubCategory(oldSubCategoryId, newSubCategory);
            return Ok();
        }

        [HttpDelete("DeleteSubCategory/{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            await _subCategoryRepository.DeleteSubCategory(id);
            return Ok();
        }

        [HttpGet("GetAllSubCategories")]
        public async Task<IActionResult> GetAllSubCategories()
        {
            return Ok(await _subCategoryRepository.GetAllSubCategories());
        }
    }
}

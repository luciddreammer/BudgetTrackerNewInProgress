using BudgetTracker.Data.Models;

namespace BudgetTracker.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<SubCategory> AddNewSubCategory(SubCategory subCategory);
        Task<SubCategory> ModifySubCategory(int oldSubCategoryId, SubCategory newSubCategory);
        Task<bool> DeleteSubCategory(int subCategoryId);
        Task<List<SubCategory>> GetAllSubCategories();

    }
}

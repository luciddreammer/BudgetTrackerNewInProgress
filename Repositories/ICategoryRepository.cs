using BudgetTracker.Models;

namespace BudgetTracker.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddNewCategory(Category category);
        Task<Category> ModifyCategory(int oldCategoryId, Category newCategory);
        Task<bool> DeleteCategory(int id);
        Task<List<Category>> GetAllCategories();
    }
}

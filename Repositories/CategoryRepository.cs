using BudgetTracker.Data.DataBase;
using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetTrackerContext _context;

        public CategoryRepository(BudgetTrackerContext context)
        {
            _context = context;
        }

        public async Task<Category> AddNewCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            _context.Categories.Remove(_context.Categories.First(i => i.Id == id));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category> ModifyCategory(int oldCategoryId, Category newCategory)
        {
            var oldOne = _context.Categories.FirstOrDefault(id => id.Id == oldCategoryId);
            oldOne.Name = newCategory.Name;
            await _context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}

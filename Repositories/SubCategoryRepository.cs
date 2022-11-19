using BudgetTracker.Data.DataBase;
using BudgetTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly BudgetTrackerContext _context;

        public SubCategoryRepository(BudgetTrackerContext context)
        {
            _context = context;
        }

        public async Task<SubCategory> AddNewSubCategory(SubCategory subCategory)
        {
            await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<bool> DeleteSubCategory(int subCategoryId)
        {
            _context.Remove(_context.SubCategories.First(id => id.Id== subCategoryId));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SubCategory>> GetAllSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public Task<SubCategory> ModifySubCategory(int oldSubCategoryId, SubCategory newSubCategory)
        {
            throw new NotImplementedException();
        }
    }
}

namespace BudgetTracker.Repositories
{
    public interface ICategoryRepository
    {
        Task AddNewCategory();
        Task ModifyCategory();
        Task DeleteCategory();
    }
}

using BudgetTracker.Models;

namespace BudgetTracker.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransaction(string name, double ammount, DateTime dateTime, string description, string whoPaid, int subCategoryId);
        Task<bool> DeleteTransaction(int transactionId);
        Task<Transaction> ModifyTransaction(int transactionId, string name, double ammount, DateTime dateTime, string description, string whoPaid, int subCategoryId);
        Task<List<Transaction>> GetAllTransactions();
        Task<List<Transaction>> GetTransactionByFilters(DateTime? from, DateTime? to, string? owner, double? ammountFrom, double? ammountTo, int? subCategoryId);
    }
}

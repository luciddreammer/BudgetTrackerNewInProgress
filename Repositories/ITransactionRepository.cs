using BudgetTracker.Models;

namespace BudgetTracker.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransaction(string name, double ammount, DateTime dateTime, string description, string whoPaid);
        Task<bool> DeleteTransaction(Transaction transaction);
        Task<Transaction> ModifyTransaction(Transaction transaction, string name, double ammount, DateTime dateTime, string description, string whoPaid);

        //Czy to powinno być również tu, czy w innym interface? Czy użyć tu jakiegoś wzorca?
        Task<List<Transaction>> GetAllTransactions();
        Task<List<Transaction>> GetTransactionsByDate(DateTime dateTimeFrom, DateTime dateTimeTo);
        Task<List<Transaction>> GetTransactionsByOwner(string owner);
        Task<List<Transaction>> GetTransactionsByAmmount(double ammountFrom, double ammountTo);
        Task<List<Transaction>> GetTransactionByCategory(Category category);
        Task<List<Transaction>> GetTransactionByFilters(DateTime? from, DateTime? to, string? owner, double? ammountFrom, double? ammountTo, int? categoryId);
    }
}

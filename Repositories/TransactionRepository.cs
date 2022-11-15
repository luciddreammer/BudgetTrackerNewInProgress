using BudgetTracker.Data.DataBase;
using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BudgetTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BudgetTrackerContext _context;

        public TransactionRepository(BudgetTrackerContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddTransaction(string name, double ammount, DateTime dateTime, string description, string whoPaid)
        {
            var newTransaction = new Transaction()
            {
                Name = name,
                Ammount = ammount,
                DateTimeTransaction = dateTime,
                Description = description,
                WhoPaid = whoPaid
            };
            await _context.Transactions.AddAsync(newTransaction);
            await _context.SaveChangesAsync();
            return newTransaction;
        }
        public async Task<bool> DeleteTransaction(Transaction transaction)
        {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return true;
        }
        public async Task<Transaction> ModifyTransaction(Transaction transaction,string name, double ammount, DateTime dateTime, string description, string whoPaid)
        {
            transaction.Name = name;
            transaction.Ammount = ammount;
            transaction.DateTimeTransaction = dateTime;
            transaction.Description = description;
            transaction.WhoPaid = whoPaid;
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<List<Transaction>> GetAllTransactions()
        {
           return await _context.Transactions.ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactionsByDate(DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            return await _context.Transactions.Where(dt => dt.DateTimeTransaction.Date >= dateTimeFrom.Date && dt.DateTimeTransaction.Date <= dateTimeTo.Date).ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactionsByOwner(string owner)
        {
            return await _context.Transactions.Where(o => o.WhoPaid == owner).ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactionsByAmmount(double ammountFrom, double ammountTo)
        {
            return await _context.Transactions.Where(a => a.Ammount > ammountFrom && a.Ammount < ammountTo).ToListAsync();
        }
        public async Task<List<Transaction>> GetTransactionByCategory(Category category)
        {
            return await _context.Transactions.Where(c => c.Category == category).ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionByFilters(DateTime? from, DateTime? to, string? owner, double? ammountFrom, double? ammountTo, int? categoryId)
        {
            IQueryable<Transaction> query = _context.Transactions.AsQueryable();
            if(from.HasValue)
            {
                query = query.Where(i => i.DateTimeTransaction >= from);
            }
            if(to.HasValue)
            {
                query = query.Where(i => i.DateTimeTransaction <= to);
            }
            if(owner != null)
            {
                query = query.Where(i => i.WhoPaid == owner);
            }
            if(ammountFrom!= null)
            {
                query = query.Where(i => i.Ammount >= ammountFrom);
            }
            if(ammountTo!= null)
            {
                query = query.Where(i => i.Ammount <= ammountTo);
            }
            if(categoryId != null)
            {
                query = query.Where(i => i.CategoryId == categoryId);
            }

            return await query.ToListAsync();
        }
    }
}

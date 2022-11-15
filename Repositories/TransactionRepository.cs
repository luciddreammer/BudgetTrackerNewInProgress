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
        public async Task<bool> DeleteTransaction(int transactionId)
        {
                _context.Transactions.Remove(_context.Transactions.First(id => id.Id == transactionId));
                await _context.SaveChangesAsync();
                return true;
        }
        public async Task<Transaction> ModifyTransaction(int transactionId, string name, double ammount, DateTime dateTime, string description, string whoPaid)
        {
            var transaction = _context.Transactions.FirstOrDefault(id => id.Id == transactionId);
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

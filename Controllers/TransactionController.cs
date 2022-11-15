using BudgetTracker.Models;
using BudgetTracker.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            await _transactionRepository.AddTransaction(transaction.Name, transaction.Ammount, transaction.DateTimeTransaction, transaction.Description, transaction.WhoPaid);
            return Ok();
        }

        [HttpGet("GetTransactions/{owner}")]
        public async Task<IActionResult> GetTransactionByOwner(string owner)
        {
            return Ok(await _transactionRepository.GetTransactionsByOwner(owner));
        }

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(await _transactionRepository.GetAllTransactions());
        }

        [HttpGet("GetTransaction/ByDate")]
        public async Task<IActionResult> GetTransactionsByDate(DateTime from, DateTime to)
        {
            return Ok(await _transactionRepository.GetTransactionsByDate(from, to));
        }

        [HttpGet("GetTransaction/ByFilters")]
        public async Task<IActionResult> GetTransactionByFilters(DateTime? from, DateTime? to, string? owner, double? ammountFrom, double? ammountTo, int? categoryId)
        {
            
            return Ok(await _transactionRepository.GetTransactionByFilters(from,to,owner,ammountFrom,ammountTo,categoryId));
        }
    }
}

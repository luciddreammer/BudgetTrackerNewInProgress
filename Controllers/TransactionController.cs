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

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            return Ok(await _transactionRepository.GetAllTransactions());
        }

        [HttpGet("GetTransaction/ByFilters")]
        public async Task<IActionResult> GetTransactionByFilters(DateTime? from, DateTime? to, string? owner, double? ammountFrom, double? ammountTo, int? categoryId)
        {
            return Ok(await _transactionRepository.GetTransactionByFilters(from,to,owner,ammountFrom,ammountTo,categoryId));
        }

        [HttpDelete("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            return Ok(await _transactionRepository.DeleteTransaction(id));
        }

        [HttpPut("ModifyTransaction")]
        public async Task<IActionResult> ModifyTransaction(int transasctionId, string name, double ammount, DateTime dateTime, string description, string whoPaid)
        {
            return Ok(await _transactionRepository.ModifyTransaction(transasctionId, name, ammount, dateTime, description,whoPaid));
        }
    }
}

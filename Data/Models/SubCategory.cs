using BudgetTracker.Models;
using System.ComponentModel.DataAnnotations;


namespace BudgetTracker.Data.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Transaction>? TransactionList { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

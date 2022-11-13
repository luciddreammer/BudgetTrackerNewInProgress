using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Category> CategoryList { get; set; } 
        public List<Transaction> TransactionList {get; set; }
    }
}

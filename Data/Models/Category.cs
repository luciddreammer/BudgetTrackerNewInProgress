using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Transaction>? TransactionList { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}

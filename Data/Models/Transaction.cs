using BudgetTracker.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Ammount { get; set; }
        public DateTime DateTimeTransaction { get; set; }
        public string? Description { get; set; }
        public string WhoPaid { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}

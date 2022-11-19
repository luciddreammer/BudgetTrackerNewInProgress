using BudgetTracker.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}

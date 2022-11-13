using BudgetTracker.Models;
using Microsoft.EntityFrameworkCore;


namespace BudgetTracker.Data.DataBase
{
    public class BudgetTrackerContext : DbContext
    {
        public BudgetTrackerContext(DbContextOptions<BudgetTrackerContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne(u => u.User).WithMany(t => t.TransactionList).HasForeignKey(u => u.UserId);/*.OnDelete(DeleteBehavior.NoAction);*/
            modelBuilder.Entity<Transaction>().HasOne(c => c.Category).WithMany(t => t.TransactionList).HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().HasOne(u => u.User).WithMany(c => c.CategoryList).HasForeignKey(u => u.UserId);
        }

    }
}

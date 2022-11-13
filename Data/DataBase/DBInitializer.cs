using BudgetTracker.Data.DataBase;
using BudgetTracker.Models;

namespace BudgetTracker.Data
{
    public class DBInitializer
    {
        public static void Initialize(BudgetTrackerContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new User()
                {
                    Login = "TestLogin",
                    Password = "TestPassword",
                    Email = "TestEmail"
                });
                context.SaveChanges();
            }
            if(!context.Transactions.Any())
            {
                context.Transactions.Add(new Transaction()
                {
                    Name = "TestTransaction",
                    Ammount = 100,
                    DateTimeTransaction = DateTime.Now,
                    Description = null,
                    WhoPaid = "Szymon"
                });
                context.SaveChanges();
            }
            if(!context.Categories.Any())
            {
                context.Categories.Add(new Category()
                {
                    Name = "TestName"
                });
                context.SaveChanges();
            }
        }
    }
}

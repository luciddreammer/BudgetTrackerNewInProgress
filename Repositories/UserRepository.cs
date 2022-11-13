using BudgetTracker.Data.DataBase;
using BudgetTracker.Models;

namespace BudgetTracker.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly BudgetTrackerContext _context;

        public UserRepository(BudgetTrackerContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        Task IUserRepository.DeleteUser()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string login)
        {
            var user = await _context.Users.FindAsync(login);
            return user;
        }

        Task IUserRepository.ModifyUser()
        {
            throw new NotImplementedException();
        }
    }
}

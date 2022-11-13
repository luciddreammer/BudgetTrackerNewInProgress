using BudgetTracker.Models;

namespace BudgetTracker.Services
{
    public interface IAuthenticationService
    {
        Task<User> RegisterUser(string email, string login, string password);
        Task<bool> LoginUser(string login, string password);
        Task LogoutUser();
    }
}

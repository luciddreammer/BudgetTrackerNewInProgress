using BudgetTracker.Models;

namespace BudgetTracker.Repositories
{
    public interface IUserRepository //Co wypychamy do kontrollera, bebechy będą miały osobny interface, np. ILogin: Autoryzacja, validacja itd.
    {
        Task<User> AddUser(User user);
        Task<User> GetUser(string login);
        Task DeleteUser();
        Task ModifyUser();
    }
}

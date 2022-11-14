using BudgetTracker.Data.DataBase;
using BudgetTracker.Models;
using BudgetTracker.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BudgetTracker.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IUserRepository userRepository, IPasswordHasher<User> passwordHasherqwe)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> LoginUser(string login, string password)
        {
            var user = await _userRepository.GetUser(login);
            if (user == null)
            {
                return false;
            }
            if(user.Password != _passwordHasher.HashPassword(user, password))
            { 
                return false; 
            }
            return true;
        }

        public Task LogoutUser()
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUser(string email, string login, string password)
        {
            var newUser = new User()
            {
                Email = email,
                Login = login,
            };
            newUser.Password = _passwordHasher.HashPassword(newUser, password);
            await _userRepository.AddUser(newUser);

            return newUser;
        }
    }
}

using BudgetTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
       private readonly IAuthenticationService _authenticationService;

       public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(string email, string login, string password)
        {
            await _authenticationService.RegisterUser(email, login, password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(string login, string password)
        {
            var result = await _authenticationService.LoginUser(login, password);
            if(result)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

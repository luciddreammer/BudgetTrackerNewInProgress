using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Cucumber.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

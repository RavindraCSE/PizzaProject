using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

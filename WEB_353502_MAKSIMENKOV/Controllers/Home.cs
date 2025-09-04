using Microsoft.AspNetCore.Mvc;

namespace WEB_353502_MAKSIMENKOV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

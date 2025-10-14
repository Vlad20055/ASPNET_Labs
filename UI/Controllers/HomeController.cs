using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var listItems = new List<ListDemo>
            {
                new ListDemo { Id = 1, Name = "Вариант 1" },
                new ListDemo { Id = 2, Name = "Вариант 2" },
                new ListDemo { Id = 3, Name = "Вариант 3" }
            };

            ViewData["SelectListItems"] = new SelectList(listItems, "Id", "Name");

            ViewData["TitleText"] = "Лабораторная работа №2";
            return View();
        }
    }
}

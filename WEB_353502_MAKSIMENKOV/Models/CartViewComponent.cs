using Microsoft.AspNetCore.Mvc;
using UI.Models;

public class CartViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var model = new CartModel
        {
            Count = 0,
            Price = "00,0 руб"
        };

        return View(model);
    }
}
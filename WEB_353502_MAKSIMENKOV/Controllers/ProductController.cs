using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

public class ProductController : Controller
{
    private IProductService _productService;

    public ProductController(IProductService productService,
                             ICategoryService categoryService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var productResponse = await _productService.GetProductListAsync(null);

        if (!productResponse.Successfull)
        {
            return NotFound(productResponse.ErrorMessage);
        }

        return View(productResponse.Data.Items);
    }
}

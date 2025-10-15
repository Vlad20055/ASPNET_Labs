using DOMAIN.Entities;
using Microsoft.AspNetCore.Mvc;
using UI.Services.ProductService;
using UI.Services.CategoryService;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // Index — принимает normalizedName категории
        public async Task<IActionResult> Index(string? category, int pageNo = 1)
        {
            // Получаем список категорий
            var categoryResponse = await _categoryService.GetCategoryListAsync();
            if (!categoryResponse.Successfull)
                return NotFound(categoryResponse.ErrorMessage);

            var categories = categoryResponse.Data ?? new List<Category>();

            // Определяем отображаемое имя текущей категории
            string currentCategoryName = "Все";
            if (!string.IsNullOrEmpty(category))
            {
                var found = categories.FirstOrDefault(c => c.NormalizedName == category);
                currentCategoryName = found?.Name ?? "Не найдено";
            }

            // Получаем список продуктов (фильтрация внутри сервиса по normalizedName)
            var productResponse = await _productService.GetProductListAsync(category, pageNo);
            if (!productResponse.Successfull)
                return NotFound(productResponse.ErrorMessage);

            // Передаём категории и текущее имя в представление
            ViewData["Categories"] = categories;
            ViewData["currentCategory"] = currentCategoryName;
            ViewData["categoryNormalizedName"] = category;

            // Передаём в View список продуктов (модель — IEnumerable<Product>)
            return View(productResponse.Data);
        }
    }
}

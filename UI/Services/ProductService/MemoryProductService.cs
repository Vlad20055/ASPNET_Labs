namespace UI.Services.ProductService;

public class MemoryProductService : IProductService
{
    private readonly List<Product> _products;
    private readonly List<Category> _categories;

    public MemoryProductService(ICategoryService categoryService)
    {
        // Получаем список категорий из другого сервиса
        _categories = categoryService
            .GetCategoryListAsync()
            .Result
            .Data ?? new List<Category>();

        // Заполняем список товаров
        _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Катушка Shimano FX 2500",
                Description = "Надёжная катушка для спиннинговой ловли, лёгкая и прочная.",
                CategoryID = 1,
                Price = 5400,
                Image = "../images/Reel_Shimano_FX_2500.jpg",
                MimeType = "image/jpeg"
            },
            new Product
            {
                Id = 2,
                Name = "Фидерное удилище Flagman Squadron Pro",
                Description = "Качественное фидерное удилище для средних дистанций.",
                CategoryID = 2,
                Price = 8200,
                Image = "../images/Feeder_Flagman_Squadron.jpg",
                MimeType = "image/jpeg"
            },
            new Product
            {
                Id = 3,
                Name = "Леска Shimano Technium 0.25 мм",
                Description = "Износостойкая леска для ловли на дальних дистанциях.",
                CategoryID = 3,
                Price = 900,
                Image = "../images/Line_Shimano_Technium.jpg",
                MimeType = "image/jpeg"
            },
            new Product
            {
                Id = 4,
                Name = "Крючки Owner №6",
                Description = "Надёжные крючки для ловли карпа и карася.",
                CategoryID = 4,
                Price = 350,
                Image = "../images/Hooks_Owner_6.jpg",
                MimeType = "image/jpeg"
            },
            new Product
            {
                Id = 5,
                Name = "Спиннинг Daiwa Ninja 2.40 м",
                Description = "Универсальный спиннинг среднего строя для начинающих и опытных рыболовов.",
                CategoryID = 5,
                Price = 6700,
                Image = "../images/Rod_Daiwa_Ninja.png",
                MimeType = "image/png"
            },
            new Product
            {
                Id = 6,
                Name = "Блёсна Mepps Aglia №3",
                Description = "Классическая вращающаяся блесна, эффективна на окуня и щуку.",
                CategoryID = 6,
                Price = 450,
                Image = "../images/Spinner_Mepps_Aglia_3.jpg",
                MimeType = "image/jpeg"
            }
        };
    }

    // На данном этапе реализуем только GetProductListAsync
    public Task<ResponseData<ListModel<Product>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
    {
        // Количество элементов на странице (если потом понадобится пагинация)
        const int pageSize = 10;

        // Фильтрация по категории, если указано имя категории
        var query = _products.AsQueryable();

        if (!string.IsNullOrEmpty(categoryNormalizedName))
        {
            var category = _categories
                .FirstOrDefault(c => c.NormalizedName == categoryNormalizedName);

            if (category != null)
                query = query.Where(p => p.CategoryID == category.Id);
            else
                return Task.FromResult(
                    ResponseData<ListModel<Product>>.Error($"Категория '{categoryNormalizedName}' не найдена")
                );
        }

        // Всего страниц (на случай будущей пагинации)
        var totalItems = query.Count();
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        // Выбираем текущую страницу
        var items = query
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        // Создаём модель для ответа
        var model = new ListModel<Product>
        {
            Items = items,
            CurrentPage = pageNo,
            TotalPages = totalPages
        };

        // Возвращаем успешный результат
        return Task.FromResult(ResponseData<ListModel<Product>>.Success(model));
    }


    public Task<ResponseData<Product>> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(int id, Product product, IFormFile? formFile)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseData<Product>> CreateProductAsync(Product product, IFormFile? formFile)
    {
        throw new NotImplementedException();
    }
}
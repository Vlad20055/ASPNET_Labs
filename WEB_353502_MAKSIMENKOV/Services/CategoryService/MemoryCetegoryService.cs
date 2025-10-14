namespace UI.Services.CategoryService;

public class MemoryCategoryService : ICategoryService
{
    public Task<ResponseData<List<Category>>> GetCategoryListAsync()
    {
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Катушки",   NormalizedName = "reels" },
            new Category { Id = 2, Name = "Фидеры",    NormalizedName = "feeders" },
            new Category { Id = 3, Name = "Лески",     NormalizedName = "lines" },
            new Category { Id = 4, Name = "Крючки",    NormalizedName = "hooks" },
            new Category { Id = 5, Name = "Спиннинги", NormalizedName = "spinnings" },
            new Category { Id = 6, Name = "Блёсны",    NormalizedName = "spinners" }
        };
        var result = ResponseData<List<Category>>.Success(categories);
        return Task.FromResult(result);
    }
}

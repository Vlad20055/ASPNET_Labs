namespace UI.Extensions;

public static class HostingExtensions
{
    public static void RegisterCustomServices(this WebApplicationBuilder builder)
    {
        // регистрация сервиса категорий
        builder.Services.AddScoped<ICategoryService, MemoryCategoryService>();
        // регистрация сервиса товаров
        builder.Services.AddScoped<IProductService, MemoryProductService>();
    }
}

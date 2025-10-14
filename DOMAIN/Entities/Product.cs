namespace DOMAIN.Entities;

public class Product
{
    public int Id { set; get; }
    public string? Name { set; get; }
    public string? Description { set; get; }
    public int CategoryID { set; get; }
    public decimal Price { set; get; }
    public string? Image { set; get; }
    public string? MimeType { get; set; }
}

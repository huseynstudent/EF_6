namespace EF_6.Entities;

public class Category :BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}

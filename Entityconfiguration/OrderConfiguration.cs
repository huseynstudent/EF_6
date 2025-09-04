using EF_6.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_6.Entityconfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.OrderNumber).IsRequired().HasMaxLength(15);

        builder.HasMany(o => o.Products)
               .WithMany(p => p.Orders)
               .UsingEntity<Dictionary<string, object>>(
                   "OrderProduct",
                   j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.Cascade),
                   j => j.HasOne<Order>().WithMany().HasForeignKey("OrderId").OnDelete(DeleteBehavior.Cascade),
                   j =>
                   {
                       j.HasKey("OrderId", "ProductId");
                       j.ToTable("OrderProducts");
                   });
    }
}
using EF_6.Entities;
using Microsoft.EntityFrameworkCore;
namespace EF_6.Context;

class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=STHQ0128-08;Initial Catalog=Market;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        mod
    }
}

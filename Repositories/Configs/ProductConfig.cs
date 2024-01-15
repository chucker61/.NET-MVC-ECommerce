using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product() { Id = 1, CategoryId = 2, ImagePath = "/images/1.jpeg", Name = "Computer", Price = 24599, ShowCase = false },
            new Product() { Id = 2, CategoryId = 2, ImagePath = "/images/2.jpeg", Name = "Television", Price = 5999, ShowCase = false },
            new Product() { Id = 3, CategoryId = 2, ImagePath = "/images/3.jpeg", Name = "Keyboard", Price = 150, ShowCase = false },
            new Product() { Id = 4, CategoryId = 2, ImagePath = "/images/4.jpeg", Name = "Mouse", Price = 65, ShowCase = false },
            new Product() { Id = 5, CategoryId = 2, ImagePath = "/images/5.jpeg", Name = "Monitor", Price = 3400, ShowCase = false },
            new Product() { Id = 6, CategoryId = 2, ImagePath = "/images/6.jpeg", Name = "Laptop", Price = 14569, ShowCase = true },
            new Product() { Id = 7, CategoryId = 2, ImagePath = "/images/7.jpeg", Name = "Speaker", Price = 569, ShowCase = true },
            new Product() { Id = 8, CategoryId = 1, ImagePath = "/images/8.jpeg", Name = "Bozkurtlar", Price = 7, ShowCase = true },
            new Product() { Id = 9, CategoryId = 1, ImagePath = "/images/9.jpeg", Name = "Deli Kurt", Price = 50, ShowCase = false }
        );
    }
}
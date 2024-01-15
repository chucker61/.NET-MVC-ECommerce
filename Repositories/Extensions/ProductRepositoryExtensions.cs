using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Extensions;

public static class ProductRepositoryExtensions
{
    public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
    {
        return categoryId is null
            ? products.Include(p => p.Category)
            : products.Include(p => p.Category).Where(p => p.CategoryId.Equals(categoryId));
    }

    public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, string? SearchTerm)
    {
        return string.IsNullOrWhiteSpace(SearchTerm)
        ? products
        : products.Where(p => p.Name.ToLower().Contains(SearchTerm.ToLower()));
    }

    public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products, int? minPrice, int? maxPrice, bool isValidPrice)
    {
        return isValidPrice
        ? products.Where(p => p.Price >= minPrice && p.Price <= maxPrice)
        : products;
    }

    public static IQueryable<Product> ToPaginate(this IQueryable<Product> product, int pageSize, int pageNumber)
    {
        return product.Skip(((pageNumber-1)*pageSize)).Take(pageSize);
    }
}
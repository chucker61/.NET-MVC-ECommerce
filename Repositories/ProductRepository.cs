using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;
using SQLitePCL;

namespace Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateOneProduct(Product product)
    {
        Create(product);
    }

    public void DeleteOneProduct(Product product)
    {
        Remove(product);
    }

    public IQueryable<Product> GetAllProducts(bool trackChanges)
    {
        return FindAll(trackChanges);
    }

    public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters)
    {
        return _context.Products
                .FilteredByCategoryId(parameters.CategoryId)
                .FilteredBySearchTerm(parameters.SearchTerm)
                .FilteredByPrice(parameters.MinPrice,parameters.MaxPrice,parameters.IsValidPrice)
                .ToPaginate(parameters.PageSize,parameters.PageNumber);
    }

    public IQueryable<Product> GetLatestProducts(int n, bool trackChanges)
    {
        return FindAll(trackChanges).OrderByDescending(p => p.Id).Take(n);
    }

    public Product? GetOneProductById(int id, bool trackChanges)
    {
        return FindByCondition(p => p.Id.Equals(id), trackChanges);
    }

    public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
    {
        return FindAll(trackChanges).Where(p => p.ShowCase.Equals(true));
    }

    public void UpdateOneProduct(Product product)
    {
        Update(product);
    }
}

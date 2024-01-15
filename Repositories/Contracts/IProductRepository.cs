using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts;

public interface IProductRepository : IRepositoryBase<Product>
{
    IQueryable<Product> GetAllProducts(bool trackChanges);
    IQueryable<Product> GetLatestProducts(int n, bool trackChanges);
    IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters);
    IQueryable<Product> GetShowcaseProducts(bool trackChanges);
    Product? GetOneProductById(int id, bool trackChanges);
    void CreateOneProduct(Product product);
    void DeleteOneProduct(Product product);
    void UpdateOneProduct(Product product);
}

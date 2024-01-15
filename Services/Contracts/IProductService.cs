using System.IO.Compression;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    IEnumerable<Product> GetLatestProducts(int n, bool trackChanges);
    IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters);
    IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
    Product? GetOneProductById(int id, bool trackChanges);
    ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    void CreateOneProduct(ProductDtoForInsertions productDto);
    void UpdateOneProduct(ProductDtoForUpdate product);
    void DeleteOneProduct(int id);
}
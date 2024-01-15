using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public void CreateOneProduct(ProductDtoForInsertions productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        _manager.Product.CreateOneProduct(product);
        _manager.Save();
    }

    public void DeleteOneProduct(int id)
    {
        var product = GetOneProductById(id, false);
        if (product is not null)
        {
            _manager.Product.DeleteOneProduct(product);
            _manager.Save();
        }
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        return _manager.Product.GetAllProducts(trackChanges);
    }

    public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters)
    {
        return _manager.Product.GetAllProductsWithDetails(parameters);
    }

    public IEnumerable<Product> GetLatestProducts(int n, bool trackChanges)
    {
        return _manager.Product.GetLatestProducts(n,trackChanges);
    }

    public Product? GetOneProductById(int id, bool trackChanges)
    {
        return _manager.Product.GetOneProductById(id, trackChanges);
    }

    public ProductDtoForUpdate GetOneProductForUpdate(int id,bool trackChanges)
    {
        var product = _manager.Product.GetOneProductById(id,trackChanges);
        var entity = _mapper.Map<ProductDtoForUpdate>(product);
        return entity;
    }

    public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
    {
        return _manager.Product.GetShowcaseProducts(trackChanges);
    }

    public void UpdateOneProduct(ProductDtoForUpdate productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _manager.Product.UpdateOneProduct(product);
        _manager.Save();
    }
}
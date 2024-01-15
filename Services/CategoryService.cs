using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _manager;

    public CategoryService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IEnumerable<Category> GetAllCategories(bool trackChanges)
    {
        return _manager.Category.GetAllCategories(trackChanges);
    }

    public Category? GetOneCategoryById(int id, bool trackChanges)
    {
        return _manager.Category.GetOneCategoryById(id,trackChanges);
    }

    
}
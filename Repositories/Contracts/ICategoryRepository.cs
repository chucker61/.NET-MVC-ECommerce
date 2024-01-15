using Entities.Models;

namespace Repositories.Contracts;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    IQueryable<Category> GetAllCategories(bool trackChanges);
    Category? GetOneCategoryById(int id, bool trackChanges);
}
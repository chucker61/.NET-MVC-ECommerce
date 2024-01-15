using Entities.Models;

namespace Repositories.Contracts;

public interface IOrderRepository : IRepositoryBase<Order>
{
    IQueryable<Order> Orders(bool trackChanges);
    Order? GetOneOrder(int id,bool trackChanges);
    void Complete(int id, bool trackChanges);
    void SaveOrder(Order order);
    int NumberOfInProcess { get; }
}
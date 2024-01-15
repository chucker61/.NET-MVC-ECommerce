using Entities.Models;

namespace Services.Contracts;

public interface IOrderService
{
    IQueryable<Order> Orders(bool trackChanges);
    Order? GetOneOrder(int id,bool trackChanges);
    void Complete(int id, bool trackChanges);
    void SaveOrder(Order order);
    int NumberOfInProcess { get; }
}
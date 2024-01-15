using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _manager;

    public OrderService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

    public void Complete(int id, bool trackChanges)
    {
        _manager.Order.Complete(id,trackChanges);
        _manager.Save();
    }

    public Order? GetOneOrder(int id, bool trackChanges)
    {
        return _manager.Order.GetOneOrder(id,trackChanges);
    }

    public IQueryable<Order> Orders(bool trackChanges)
    {
        return _manager.Order.Orders(trackChanges);
    }

    public void SaveOrder(Order order)
    {
        _manager.Order.SaveOrder(order);
        _manager.Save();
    }
}
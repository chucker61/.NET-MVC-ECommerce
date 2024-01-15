using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Contracts;

namespace Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext context) : base(context)
    {
    }

    public int NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));

    public void Complete(int id, bool trackChanges)
    {
        var order = FindByCondition(o => o.Id.Equals(id), trackChanges);
        if (order is null)
            throw new NullReferenceException();
        order.Shipped = true;
    }

    public Order? GetOneOrder(int id, bool trackChanges)
    {
        return FindByCondition(o => o.Id.Equals(id), trackChanges);
    }

    public IQueryable<Order> Orders(bool trackChanges)
    {
        return FindAll(trackChanges).Include(o => o.Lines).ThenInclude(cl => cl.Product).OrderBy(o => o.Shipped).ThenByDescending(o => o.Id);
    }


    public void SaveOrder(Order order)
    {
        _context.AttachRange(order.Lines.Select(l => l.Product));
        if (order.Id.Equals(0))
            _context.Orders.Add(order);
    }
}
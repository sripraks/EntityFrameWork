using DynamiteStore.Data.Interfaces;
using DynamiteStore.Data.Context;

namespace DynamiteStore.Data.UnitOfWork
{
  public class OrderUnitOfWork : IUnitOfWork<OrderContext>
  {
     private readonly OrderContext _context;

    public OrderUnitOfWork()
    {
        _context = new OrderContext();
    }

    public OrderUnitOfWork(OrderContext context)
    {
      _context = context;
    }
    public int Save()
    {
      return _context.SaveChanges();
    }

    public OrderContext Context
    {
      get { return _context; }
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}

using DynamiteStore.Data.Interfaces;
using DynamiteStore.Data.Context;

namespace DynamiteStore.Data.UnitOfWork
{
  public class CustomerUnitOfWork : IUnitOfWork<CustomerContext>
  {
     private readonly CustomerContext _context;

    public CustomerUnitOfWork()
    {
        _context = new CustomerContext();
    }

    public CustomerUnitOfWork(CustomerContext context)
    {
      _context = context;
    }
    public int Save()
    {
      return _context.SaveChanges();
    }

    public CustomerContext Context
    {
      get { return _context; }
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}

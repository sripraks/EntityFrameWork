using System;
using System.Data.Entity;

namespace DynamiteStore.Data.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        int Save();
        TContext Context { get; }

    }
}

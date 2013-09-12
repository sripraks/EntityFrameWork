using System.Data.Entity;
using DynamiteStore.DomainModel;

namespace DynamiteStore.Data.Context
{
    public class OrderContext : BaseContext<OrderContext>
    {
        public DbSet<Order> Orders { get; set; }
    }
}

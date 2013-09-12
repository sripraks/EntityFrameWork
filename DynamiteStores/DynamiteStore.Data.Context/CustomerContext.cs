using System.Data.Entity;
using DynamiteStore.DomainModel;
namespace DynamiteStore.Data.Context
{
    public class CustomerContext : BaseContext<CustomerContext>
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Shipment>();
            modelBuilder.Ignore<Category>();
            modelBuilder.Ignore<LineItem>();
            modelBuilder.Ignore<Product>();
            modelBuilder.Ignore<Payment>();
        }
    }
}

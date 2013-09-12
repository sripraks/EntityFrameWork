using System.Data.Entity;
using DynamiteStore.DomainModel;

namespace DynamiteStore.DBSetup
{
    public class DynamiteStores : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryHistory> SalaryHistories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Return> Returns { get; set; }

        public DynamiteStores() : base("DynamiteStores")
        {
        }

    }
}


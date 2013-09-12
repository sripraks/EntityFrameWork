using System;
using DynamiteStore.Data.CustomerRepository;
using System.Linq;
using DynamiteStore.Data.UnitOfWork;
using DynamiteStore.DomainModel;
using System.Collections.Generic;
using DynamiteStore.DBObjectState;
using DynamiteStore.Business;

namespace DynamiteStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //System.Console.WriteLine("********* Orders Edit and Line Item ADD/UPDATE/DELETE using disconnected Entity *********");
            //ReteriveOrdersAndEditUsingDisconnectedEntity();
            //System.Console.ReadLine();


            //System.Console.WriteLine("********* Code first Dynamite DB Setup *********");
            //CodeFirstDBSetup();
            //System.Console.ReadLine();

            //System.Console.WriteLine("********* ReteriveCustomerAndEditUsingDisconnectedEntity *********");
            //ReteriveCustomerAndEditUsingDisconnectedEntity();
            //System.Console.ReadLine();

            //System.Console.WriteLine("********* ReteriveCustomerUsingCustomerRepositorywithoutUOW *********");
            //ReteriveCustomerUsingCustomerRepositorywithoutUOW();

            //System.Console.WriteLine("********* GetCustomersWhoHaveOrders *********");
            //GetCustomersWhoHaveOrders();

            //System.Console.WriteLine("********* GetCustomersWhoHaveOrdersAndIncludeOrders *********");
            //GetCustomersWhoHaveOrdersAndIncludeOrders();
            //System.Console.ReadLine();
        }

        private static void ReteriveCustomerUsingCustomerRepositorywithoutUOW()
        {
            using (var repo = new CustomerRepository())
            {
                //Note the method All is a propoerty and not a function
                var i = 1;
                foreach (var customer in repo.All)
                {
                    System.Console.WriteLine("{0}: {1} {2}",
                      i, customer.FirstName, customer.LastName);
                    i += 1;
                }

            }
        }

        private static void GetCustomersWhoHaveOrders()
        {
            using (var repo = new CustomerRepository())
            {
                //Note the method AllCustomersWhoHasOrders is a propoerty and not a function
                List<Customer> customers = new List<Customer>();
                customers = repo.AllCustomersWhoHasOrders;

                var i = 1;
                foreach (var customer in customers)
                {
                    System.Console.WriteLine("{0}: {1} {2}",
                     i, customer.FirstName, customer.LastName);
                    i += 1;
                }
            }
        }

        private static void GetCustomersWhoHaveOrdersAndIncludeOrders()
        {
            using (var repo = new CustomerRepository())
            {
                foreach (var customer in repo.AllIncluding(c => c.Orders).Where(c => c.Orders.Any()))
                {
                    System.Console.WriteLine("{0} {1} Order Count={2}",
                    customer.FirstName, customer.LastName, customer.Orders.Count);
                }
            }
        }

        private static void ReteriveCustomerAndEditUsingDisconnectedEntity()
        {

            Customer customer = CustomerBusiness.GetCustomerDetailsByKey(1);

            customer.FirstName = "Mrs." + customer.FirstName;
            customer.State = State.Modified;

            customer.Addresses.First().Street2 = "ST BED Layout";
            customer.Addresses.First().State = State.Modified;

            CustomerBusiness.AddUpdateCustomers(customer);

        }

        private static void CodeFirstDBSetup()
        {
            var customer = new Customer
            {
                FirstName = "Prakash",
                LastName = "Srinivasan",
                Phone = "91-80-25631667",
                EmailAddress = "sripraks@yahoo.com",
                Addresses = new List<Address> { new Address { Street1 = "Kormangala", City = "Bangalore" } }
            };

            var db = new DynamiteStore.DBSetup.DynamiteStores();
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        private static void ReteriveOrdersAndEditUsingDisconnectedEntity()
        {
            Order order = OrderBusiness.GetOrderDetailsByKey(6);

            // Order Edit
            order.Comment = "Comment2";
            order.State = State.Modified;

            // Line Item Edit  
            order.LineItems.Where(i => i.LineItemId == 1).FirstOrDefault().OrderQty = 600;
            order.LineItems.Where(i => i.LineItemId == 1).FirstOrDefault().State = State.Modified;

            //Line Item Delete  
            order.LineItems.Where(i => i.LineItemId == 2).FirstOrDefault().State = State.Deleted;

            //New Line Item Added
            var orderlineitem = new LineItem
            {
                OrderQty = 100,
                ProductId = 1,
                Order = order,
                UnitPrice = 5000,
                State = State.Added
            };

            order.LineItems.Add(orderlineitem);

            OrderBusiness.AddUpdateOrders(order);

        }
    }
}

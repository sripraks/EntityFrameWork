using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamiteStore.Service.Console.CustomerService;
using DynamiteStore.DomainModel;
using DynamiteStore.DBObjectState;
using DynamiteStore.Service.Console.OrderService;

namespace DynamiteStore.Service.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("********* ReteriveOrdersAndPerformCRUDOperationsUsingDisconnectedEntityOverWire *********");
            ReteriveOrdersAndEditUsingDisconnectedEntityOverWire();
            System.Console.ReadLine();

            //System.Console.WriteLine("********* ReteriveCustomerAndEditUsingDisconnectedEntityOverWire *********");
            //ReteriveCustomerAndEditUsingDisconnectedEntityOverWire();
            //System.Console.ReadLine();


        }

        private static void ReteriveCustomerAndEditUsingDisconnectedEntityOverWire()
        {
            CustomerClient customerservice = new CustomerClient();

            Customer customer = customerservice.GetCustomerDetailsByKey(1);
            customer.FirstName = "WCF" + customer.FirstName;
            customer.State = DynamiteStore.DBObjectState.State.Modified;
            customer.Addresses.First().Street2 = "WCF Street";
            customer.Addresses.First().State = DynamiteStore.DBObjectState.State.Modified;
            customerservice.AddUpdateCustomers(customer);
        }

        private static void ReteriveOrdersAndEditUsingDisconnectedEntityOverWire()
        {
            OrderClient orderservice = new OrderClient();

            Order order = orderservice.GetOrderDetailsByKey(6);

            // Order Edit
            order.Comment = "Comment2";
            order.State = State.Modified;

            // Line Item Edit  
            order.LineItems.Where(i => i.LineItemId == 1).FirstOrDefault().OrderQty = 900;
            order.LineItems.Where(i => i.LineItemId == 1).FirstOrDefault().State = State.Modified;

            //Line Item Delete  
            order.LineItems.Where(i => i.LineItemId == 4).FirstOrDefault().State = State.Deleted;

            //New Line Item Added
            var orderlineitem = new LineItem
            {
                OrderQty = 999,
                ProductId = 1,
                Order = order,
                UnitPrice = 5000,
                State = State.Added
            };

            order.LineItems.Add(orderlineitem);
            orderservice.AddUpdateOrders(order);

        }
    }
}

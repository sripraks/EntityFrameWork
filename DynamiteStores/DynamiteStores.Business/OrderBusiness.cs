using System;
using System.Collections.Generic;
using DynamiteStore.DomainModel;
using DynamiteStore.Data.OrderRepository;
 
using System.Linq;
using DynamiteStore.Data.UnitOfWork;

namespace DynamiteStore.Business
{
    public class OrderBusiness
    {
        public static Order GetOrderByKey(int orderid)
        {
            using (var ordrepo = new OrderRepository())
            {
                return ordrepo.Find(orderid);
            }
        }

        public static IQueryable<Order> GetAllOrders()
        {
            using (var ordrepo = new OrderRepository())
            {
                return ordrepo.All;
            }

        }

        public static Order GetOrderDetailsByKey(int orderId)
        {
            using (var ordrepo = new OrderRepository())
            {
                return ordrepo.AllIncluding(o => o.LineItems)
                              .Where(o => o.OrderId == orderId).First();
            }
        }

        public static void AddUpdateOrders(Order order)
        {
           using (OrderUnitOfWork uow = new OrderUnitOfWork())
            {
                using (var rep = new OrderRepository(uow))
                {
                    rep.InsertOrUpdate(order);
                    uow.Save();
                }
            }
        }

        public static void DeleteOrderByKey(int id)
        {
            using (OrderUnitOfWork uow = new OrderUnitOfWork())
            {
                using (var rep = new OrderRepository(uow))
                {
                    rep.Delete(id);
                    uow.Save();
                }
            }
        }
    }
}

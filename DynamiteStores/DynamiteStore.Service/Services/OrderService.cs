using DynamiteStore.Service.Interface;
using DynamiteStore.Business;
using DynamiteStore.DomainModel;

namespace DynamiteStore.Service.Services
{
    public class OrderService : IOrder
    {

        public Order GetOrderByKey(int orderid)
        {
            return OrderBusiness.GetOrderByKey(orderid);
        }


        public Order GetOrderDetailsByKey(int orderid)
        {
            return OrderBusiness.GetOrderDetailsByKey(orderid);
        }

        public void AddUpdateOrders(Order order)
        {
            OrderBusiness.AddUpdateOrders(order);
        }

        public void DeleteOrderByKey(int orderid)
        {
            OrderBusiness.DeleteOrderByKey(orderid);
        }

    }
}

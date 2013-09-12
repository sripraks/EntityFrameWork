using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using DynamiteStore.DomainModel;
namespace DynamiteStore.Service.Interface
{
    
    [ServiceContract]
    public partial interface IOrder
    {
        [OperationContract]
        Order GetOrderByKey(int orderid);

        [OperationContract]
        Order GetOrderDetailsByKey(int orderid);

        [OperationContract]
        void AddUpdateOrders(Order order);

        [OperationContract]
        void DeleteOrderByKey(int orderid);
    }
}
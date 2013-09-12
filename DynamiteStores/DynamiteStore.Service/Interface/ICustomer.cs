using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using DynamiteStore.DomainModel;
namespace DynamiteStore.Service.Interface
{
    
    [ServiceContract]
    public partial interface ICustomer
    {
        [OperationContract]
        Customer GetCustomerByKey(int customerid);

        [OperationContract]
        Customer GetCustomerByName(String FirstName, String LastName);

        [OperationContract]
        IQueryable<Customer> GetAllCustomers();

        [OperationContract]
        IList<Customer> GetAllCustomersByName(String FirstName, String LastName);

        [OperationContract]
        IList<Customer> GetAllCustomersWhoHasOrders();

        [OperationContract]
        Customer GetCustomerDetailsByKey(int customerId);

        [OperationContract]
        void AddUpdateCustomers(Customer customer);

        [OperationContract]
        void DeleteCustomerByKey(int id);
    }
}
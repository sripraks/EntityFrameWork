using System;
using System.Collections.Generic;
using System.Linq;
using DynamiteStore.Service.Interface;
using DynamiteStore.Business;
using DynamiteStore.DomainModel;

namespace DynamiteStore.Service.Services
{
    public class CustomerService : ICustomer
    {

        public Customer GetCustomerByKey(int customerid)
        {
            return CustomerBusiness.GetCustomerByKey(customerid);
        }

        public Customer GetCustomerByName(string FirstName, string LastName)
        {
            return CustomerBusiness.GetCustomerByName(FirstName, LastName);
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return CustomerBusiness.GetAllCustomers();
        }

        public IList<Customer> GetAllCustomersByName(string FirstName, string LastName)
        {
            return CustomerBusiness.GetAllCustomersByName(FirstName, LastName);
        }

        public IList<Customer> GetAllCustomersWhoHasOrders()
        {
            return CustomerBusiness.GetAllCustomersWhoHasOrders();
        }

        public Customer GetCustomerDetailsByKey(int customerId)
        {
            return CustomerBusiness.GetCustomerDetailsByKey(customerId);
        }

        public void AddUpdateCustomers(Customer customer)
        {
            CustomerBusiness.AddUpdateCustomers(customer);
        }

        public void DeleteCustomerByKey(int id)
        {
            CustomerBusiness.DeleteCustomerByKey(id);
        }

    }
}

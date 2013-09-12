using System;
using System.Collections.Generic;
using DynamiteStore.DomainModel;
using DynamiteStore.Data.CustomerRepository;
 
using System.Linq;
using DynamiteStore.Data.UnitOfWork;

namespace DynamiteStore.Business
{
    public class CustomerBusiness
    {

        public static Customer GetCustomerByKey(int customerid)
        {
            using (var cusrepo = new CustomerRepository())
            {
                return cusrepo.Find(customerid);
            }

        }

        public static Customer GetCustomerByName(String FirstName, String LastName)
        {
            using (var cusrepo = new CustomerRepository())
            {
                return cusrepo.FindOneCustomer(c => c.FirstName == FirstName && c.LastName == LastName);
            }

        }

        public static IQueryable<Customer> GetAllCustomers()
        {
            using (var cusrepo = new CustomerRepository())
            {
                return cusrepo.All;
            }

        }

        public static IList<Customer> GetAllCustomersByName(String FirstName, String LastName)
        {
            using (var cusrepo = new CustomerRepository())
            {
                return cusrepo.FindAllCustomers(c => c.FirstName == FirstName && c.LastName == LastName);
            }
        }

        public static IList<Customer> GetAllCustomersWhoHasOrders()
        {
            using (var cusrepo = new CustomerRepository())
            {
                return cusrepo.AllCustomersWhoHasOrders; 
            }
        }

        public static Customer GetCustomerDetailsByKey(int customerId)
        {
            using (var cusrepo = new CustomerRepository())
            {
                return cusrepo.AllIncluding(c =>c.Addresses , c=>c.Orders)
                              .Where(c => c.Id == customerId).First();
            }
        }

        public static void AddUpdateCustomers(Customer customer)
        {
           using (CustomerUnitOfWork uow = new CustomerUnitOfWork())
            {
                using (var rep = new CustomerRepository(uow))
                {
                    rep.InsertOrUpdate(customer);
                    uow.Save();
                }
            }
        }

        public static void DeleteCustomerByKey(int id)
        {
            using (CustomerUnitOfWork uow = new CustomerUnitOfWork())
            {
                using (var rep = new CustomerRepository(uow))
                {
                    rep.Delete(id);
                    uow.Save();
                }
            }
        }
    }
}

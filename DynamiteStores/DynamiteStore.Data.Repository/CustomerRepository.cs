using DynamiteStore.Data.Context;
using DynamiteStore.Data.Helpers;
using DynamiteStore.Data.Interfaces;
using DynamiteStore.Data.UnitOfWork;
using DynamiteStore.DBObjectState;
using DynamiteStore.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DynamiteStore.Data.CustomerRepository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerUnitOfWork uow)
        {
            _context = uow.Context;
        }

        public CustomerRepository()
        {
            var uow = new CustomerUnitOfWork();
            _context = uow.Context;
        }

     
        public IQueryable<Customer> All
        {
            get { return _context.Customers; }
        }
            
        public List<Customer> AllCustomersWhoHasOrders
        {
            get { return _context.Customers.Where(c => c.Orders.Any()).ToList(); }
        }
 

        public IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = _context.Customers;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Customer Find(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer FindOneCustomer(Expression<Func<Customer, bool>> criteria)
        {
            return _context.Customers.Where(criteria).FirstOrDefault();
        }

        public List<Customer> FindAllCustomers(Expression<Func<Customer, bool>> criteria)
        {
            return _context.Customers.Where(criteria).ToList(); 
        }

           public void InsertOrUpdate(Customer customer)
        {
            if (customer.State == State.Added)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                _context.Customers.Add(customer);
                _context.ApplyStateChanges();
            }
        }

    
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
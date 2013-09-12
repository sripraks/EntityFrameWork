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

namespace DynamiteStore.Data.OrderRepository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderUnitOfWork uow)
        {
            _context = uow.Context;
        }

        public OrderRepository()
        {
            var uow = new OrderUnitOfWork();
            _context = uow.Context;
        }


        public IQueryable<Order> All
        {
            get { return _context.Orders; }
        }


        public IQueryable<Order> AllIncluding(params Expression<Func<Order, object>>[] includeProperties)
        {
            IQueryable<Order> query = _context.Orders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Order Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public Order FindOneCustomer(Expression<Func<Order, bool>> criteria)
        {
            return _context.Orders.Where(criteria).FirstOrDefault();
        }


        public void InsertOrUpdate(Order order)
        {
            if (order.State == State.Added)
            {
                _context.Orders.Add(order);
            }
            else
            {
                _context.Orders.Add(order);
                _context.ApplyStateChanges();
            }
        }

        //public void InsertOrUpdate(Customer customer)
        //{
        //    if (customer.Id == default(int)) // New entity
        //    {
        //        _context.Entry(customer).State = System.Data.EntityState.Added;
        //    }
        //    else        // Existing entity
        //    {
        //        _context.Entry(customer).State = System.Data.EntityState.Modified;

        //    }
        //}

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
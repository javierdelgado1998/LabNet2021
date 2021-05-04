using Lab.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic
{
    public class CustomersQueries : BaseLogic
    {
        public Customers GetCustomer(string id)
        {
            var customer = context.Customers.Find(id.ToUpper());
            return customer;
        }
        public List<Customers> FromWashington()
        {
            var customers = context.Customers.Where(c => c.Region == "WA");
            return customers.ToList();
        }
        public List<CustomerNames> Names()
        {
            var customers = from customer in context.Customers
                            select new CustomerNames()
                            {
                                NameLower = customer.ContactName.ToLower(),
                                NameUpper = customer.ContactName.ToUpper()
                            };
            return customers.ToList();
        }
        public List<CustomerJoinOrder> JoinOrdersDate()
        {
            var customerOrders = from order in context.Orders
                                 join customer in context.Customers on
                                    order.CustomerID equals customer.CustomerID
                                 where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                                 select new CustomerJoinOrder()
                                 {
                                     CustomerName = customer.ContactName,
                                     OrderDate = (DateTime)order.OrderDate
                                 };
            return customerOrders.ToList();
        }
        public List<Customers> WashingtonTop3()
        {
            var customers = (from customer in context.Customers
                          where customer.Region == "WA"
                          select customer)
                          .Take(3);
            return customers.ToList();
        }
        public List<CustomerOrdersCount> JoinOrdersCount()
        {
            var customerOrders = from customers in context.Customers
                                 join orders in context.Orders on
                                    customers.CustomerID equals orders.CustomerID
                                 group customers by customers.CustomerID into cantidad
                                 select new CustomerOrdersCount()
                                 {
                                     CustomerID = cantidad.Key,
                                     Order = cantidad.Count()
                                 };
            return customerOrders.ToList();
        }
    }
}

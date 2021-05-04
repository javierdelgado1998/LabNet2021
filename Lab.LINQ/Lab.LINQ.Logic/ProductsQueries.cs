using Lab.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic
{
    public class ProductsQueries : BaseLogic
    {
        public List<Products> OutOfStock()
        {
            var products = context.Products.Where(p => p.UnitsInStock == 0);
            return products.ToList();
        }
        public List<Products> UnitPriceGreater()
        {
            var products = context.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            return products.ToList();
        }
        public Products FirstElement()
        {
            var product = context.Products.Where(p => p.ProductID == 789).FirstOrDefault();
            return product;
        }
        public List<Products> OrderByName()
        {
            var products = from product in context.Products
                           orderby product.ProductName
                           select product;
            return products.ToList();
        }
        public Products GetFirst()
        {
            var product = context.Products.First();
            return product;
        }
        public List<Products> OrderByUnitStock()
        {
            var products = context.Products.OrderByDescending(p => p.UnitsInStock);
            return products.ToList();
        }
    }
}

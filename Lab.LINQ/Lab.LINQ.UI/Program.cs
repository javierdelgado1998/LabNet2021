using Lab.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersQueries customersQueries = new CustomersQueries();
            ProductsQueries productsQueries = new ProductsQueries();
            CategoriesQueries categoriesQueries = new CategoriesQueries();
            bool end = false;
            try
            {
                do
                {
                    Console.WriteLine("\n0-FIN");
                    Console.WriteLine("1-QUERY 1");
                    Console.WriteLine("2-QUERY 2");
                    Console.WriteLine("3-QUERY 3");
                    Console.WriteLine("4-QUERY 4");
                    Console.WriteLine("5-QUERY 5");
                    Console.WriteLine("6-QUERY 6");
                    Console.WriteLine("7-QUERY 7");
                    Console.WriteLine("8-QUERY 8");
                    Console.WriteLine("9-QUERY 9");
                    Console.WriteLine("10-QUERY 10");
                    Console.WriteLine("11-QUERY 11");
                    Console.WriteLine("12-QUERY 12");
                    Console.WriteLine("13-QUERY 13");
                    string opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "0":
                            end = true;
                            break;
                        case "1":
                            var customer = customersQueries.GetCustomer("AROUT");
                            Console.WriteLine(customer.ContactName);
                            break;
                        case "2":
                            productsQueries.OutOfStock().ForEach(p => Console.WriteLine($"{p.ProductName} | {p.UnitsInStock}"));
                            break;
                        case "3":
                            productsQueries.UnitPriceGreater().ForEach(p => Console.WriteLine($"{p.ProductName} | {p.UnitsInStock} | {p.UnitPrice}"));
                            break;
                        case "4":
                            customersQueries.FromWashington().ForEach(c => Console.WriteLine($"{c.ContactName} | {c.Region}"));
                            break;
                        case "5":
                            var product = productsQueries.FirstElement();
                            if (product == null)
                            {
                                Console.WriteLine("El elemento es nulo");
                            }
                            else
                            {
                                Console.WriteLine(product.ProductName);
                            }
                            break;
                        case "6":
                            customersQueries.Names().ForEach(c => Console.WriteLine($"{c.NameUpper} | {c.NameLower}"));
                            break;
                        case "7":
                            customersQueries.JoinOrdersDate().ForEach(c => Console.WriteLine($"{c.CustomerName} | {c.OrderDate.ToShortDateString()}"));
                            break;
                        case "8":
                            customersQueries.WashingtonTop3().ForEach(c => Console.WriteLine(c.ContactName));
                            break;
                        case "9":
                            productsQueries.OrderByName().ForEach(p => Console.WriteLine(p.ProductName));
                            break;
                        case "10":
                            productsQueries.OrderByUnitStock().ForEach(p => Console.WriteLine($"{p.ProductName} | {p.UnitsInStock}"));
                            break;
                        case "11":
                            categoriesQueries.DistinctCategories().ForEach(c => Console.WriteLine(c.CategoryName));
                            break;
                        case "12":
                            Console.WriteLine(productsQueries.GetFirst().ProductName);
                            break;
                        case "13":
                            customersQueries.JoinOrdersCount().ForEach(c => Console.WriteLine($"{c.CustomerID} | {c.Order}"));
                            break;
                        default:
                            Console.WriteLine("!Error, ingrese un número del 1 al 13");
                            break;
                    }
                } while (!end);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

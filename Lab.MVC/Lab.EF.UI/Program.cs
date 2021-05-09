using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippersLogic shipperLogic = new ShippersLogic();
            TerritoriesLogic territorieLogic = new TerritoriesLogic();
            bool terminar = false;
            do
            {
                Console.WriteLine("1-ALTA");
                Console.WriteLine("2-BAJA");
                Console.WriteLine("3-MODIFICAR");
                Console.WriteLine("4-LISTAR");
                Console.WriteLine("5-BUSCAR");
                Console.WriteLine("6-LISTAR(Territorios)");
                Console.WriteLine("7-TERMINAR");
                string opcion = Console.ReadLine();
                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Write("\nCompany name: ");
                            string companyName = Console.ReadLine();
                            Console.Write("\nPhone: ");
                            string phone = Console.ReadLine();
                            var newShipper = new Shippers()
                            {
                                CompanyName = companyName,
                                Phone = phone
                            };
                            shipperLogic.Add(newShipper);
                            break;

                        case "2":
                            Console.Write("\nID: ");
                            shipperLogic.Delete(int.Parse(Console.ReadLine()));
                            break;

                        case "3":
                            Console.Write("\nID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("\nCompany name: ");
                            string nameUpdate = Console.ReadLine();
                            Console.Write("\nPhone: ");
                            string phoneUpdate = Console.ReadLine();
                            shipperLogic.Update(new Shippers
                            {
                                ShipperID = id,
                                CompanyName = nameUpdate,
                                Phone = phoneUpdate
                            });
                            break;

                        case "4":
                            RefreshShippers(shipperLogic);
                            break;

                        case "5":
                            Console.Write("\nID: ");
                            var shipper = shipperLogic.GetOne(int.Parse(Console.ReadLine()));
                            Console.WriteLine($"{shipper.ShipperID} | {shipper.CompanyName} | {shipper.Phone}");
                            break;

                        case "6":
                            RefreshTerritories(territorieLogic);
                            break;

                        case "7":
                            terminar = true;
                            break;

                        default:
                            Console.WriteLine("!Error, ingrese un número del 1 al 7");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ha ocurrido una excepción! {0} : {1}", ex.Message, ex.GetType());
                }
            } while (!terminar);
        }
        static void RefreshShippers(ShippersLogic shipperLogic)
        {
            foreach (var shipp in shipperLogic.GetAll())
            {
                Console.WriteLine($"{shipp.ShipperID} | {shipp.CompanyName} | {shipp.Phone}");
            }
        }
        static void RefreshTerritories(TerritoriesLogic territorieLogic)
        {
            foreach (var territorie in territorieLogic.GetAll())
            {
                Console.WriteLine($"{territorie.TerritoryID} | {territorie.TerritoryDescription.Trim()} | {territorie.RegionID}");
            }
        }
    }
}

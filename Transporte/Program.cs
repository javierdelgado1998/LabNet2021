using System;
using System.Collections.Generic;
namespace ej_transporte
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transporte> listaTransportes = new List<Transporte>
            {
                new Automovil(2), new Automovil(3), new Automovil(10), new Automovil(15), new Automovil(23),
                new Avion(50), new Avion(25), new Avion(30), new Avion(36), new Avion(42)
            };
            for (int i = 0; i < listaTransportes.Count; i++)
            {
                Console.WriteLine("{0} {1}: {2} pasajeros",listaTransportes[i].ToString(),i+1,listaTransportes[i].Pasajeros);
            }
        }
    }
}

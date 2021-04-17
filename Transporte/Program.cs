using System;
using System.Collections.Generic;
namespace ej_transporte
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Avion> listaAviones = new List<Avion>()
            {
                new Avion(5), new Avion(20), new Avion(7), new Avion(32), new Avion(13)
            };
            List<Automovil> listaAutomovil = new List<Automovil>()
            {
                new Automovil(4), new Automovil(8), new Automovil(12), new Automovil(20), new Automovil(25)
            };
            for (int i = 0; i < listaAviones.Count; i++)
            {
                Console.WriteLine("{0} {1}: {2}",listaAviones[i].ToString(),i+1,listaAviones[i].Pasajeros);
            }
            for (int i = 0; i < listaAviones.Count; i++)
            {
                Console.WriteLine("{0} {1}: {2}",listaAutomovil[i].ToString(),i+1,listaAutomovil[i].Pasajeros);
            }

        }
    }
}

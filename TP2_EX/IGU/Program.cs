using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace IGU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------EJERCICIO 1--------------");
            Ejercicio1();
            Console.ReadKey();

            Console.WriteLine("---------------EJERCICIO 2--------------");
            Ejercicio2();
            Console.ReadKey();

            Console.WriteLine("---------------EJERCICIO 3--------------");
            Logic exceptionsInit = new Logic();
            try
            {
                exceptionsInit.ThrowException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.CompleteMessage());
            }
            Console.ReadKey();

            Console.WriteLine("---------------EJERCICIO 4--------------");
            try
            {
                exceptionsInit.ThrowNoEsParException("Mensaje personalizado", 3);
            }
            catch (NoEsParException e)
            {
                MessageBox.Show(e.Message);
            }
            Console.ReadKey();
        }
        static void Ejercicio1()
        {
            try
            {
                DivisionMethod dm = new DivisionMethod();
                Console.WriteLine("Ingrese valor: ");
                dm.DivisionPorCero(int.Parse(Console.ReadLine()));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("La operación finalizo.");
            }
        }
        static void Ejercicio2()
        {
            try
            {
                DivisionMethod dm = new DivisionMethod();
                Console.WriteLine("Ingrese dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                int resultado = dm.DivisionEntera(dividendo, divisor);
                Console.WriteLine("El resultado de la división es: {0}", resultado);
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!: {0}", formatEx.Message);
            }
            catch (DivideByZeroException divideEx)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!: {0}", divideEx.Message);
            }
        }
    }
}

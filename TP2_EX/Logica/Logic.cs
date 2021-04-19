using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logic
    {
        public void ThrowException()
        {
            try
            {
                int[] numeros = new int[3];
                Console.WriteLine(numeros[4]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ThrowNoEsParException(string message, int numero)
        {
            if (numero % 2 != 0)
            {
                throw new NoEsParException(message);
            }
        }
    }
}

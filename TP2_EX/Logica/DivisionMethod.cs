using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DivisionMethod
    {
        public void DivisionPorCero(int numero)
        {
            int resultado = numero / 0;
        }
        public int DivisionEntera(int dividendo, int divisor)
        {
            int resultado = dividendo / divisor;
            return resultado;
        }
    }
}

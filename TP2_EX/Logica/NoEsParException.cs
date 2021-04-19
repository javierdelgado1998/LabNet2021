using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class NoEsParException : Exception
    {
        private string customMsg;
        public NoEsParException(string customMsg)
        {
            this.customMsg = customMsg;
        }
        public override string Message => ($"{this} : {customMsg}");
        public override string ToString()
        {
            return "NoEsParException";
        }
    }
}

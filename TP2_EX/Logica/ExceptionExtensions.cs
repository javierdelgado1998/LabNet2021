using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public static class ExceptionExtensions
    {
        public static string CompleteMessage(this Exception e)
        {
            return ($"{e.Message} : {e.GetType()}");
        }
    }
}

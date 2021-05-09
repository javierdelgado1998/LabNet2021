using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Exceptions
{
    public class FieldException : Exception
    {
        public override string Message => "Field value is invalid";
    }
}

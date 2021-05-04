using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LINQ.Logic
{
    public class CustomerJoinOrder
    {
        private string customerName;
        private DateTime orderDate;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    interface IABMLogic<T>
    {
        void Add(T entitie);
        void Delete(int id);
        void Update(T entitie);
        List<T> GetAll();
    }
}

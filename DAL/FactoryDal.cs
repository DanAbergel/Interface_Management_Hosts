using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class FactoryDal
    {
        public static IDAL GetDal() { return new DAL_imp(); }
    }
   
}

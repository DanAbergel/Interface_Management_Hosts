using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryAndSingletonDal
    {
        private static IDAL instance;
        private FactoryAndSingletonDal() { }
        public static IDAL GetDAL()
        {
                if (instance == null)
                    instance = new DAL_Xml_imp();
                return instance;
        }
    }
}

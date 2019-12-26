using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class SingletonDal
    {
        private static SingletonDal instance;
        private SingletonDal() { }
        public static SingletonDal Instance 
        {
            get
            {
                if (instance == null)
                    instance = new SingletonDal();
                return instance;
            }
        }
    }
}

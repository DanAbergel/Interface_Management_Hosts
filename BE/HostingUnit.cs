using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {
        public long HostingUnitKey = Configuration.StaticHostingUnitKey++;
        public Host Owner;
        private string HostingUnitName { get; set; }
        bool[,] Diary=new bool[12,31];

       

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HostingUnit
    {
        public long HostingUnitKey { get; set; }
        public Host Owner;
        private string HostingUnitName { get; set; }
        bool[,] Diary;

        //ctor
        public HostingUnit(Host Owner, string HostingUnitName)
        {
            this.HostingUnitKey = Configuration.StaticHostingUnitKey++;
            this.Owner = Owner;
            this.HostingUnitName = HostingUnitName;
            Diary = new bool[12,31];
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

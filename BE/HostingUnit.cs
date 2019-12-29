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
        public string HostingUnitName;
        public bool[,] Diary=new bool[12,31];
        public double pricePerDay;
       
        public override string ToString()
        {
            string str = "";
            str += "HostingUnit Key: " + HostingUnitKey;
            str +="\n"+ Owner.ToString();
            str += "\nHostingUnit Name:" + HostingUnitName;
            str += "\nPrice per day: " + pricePerDay;
            return str;
        }
    }
}

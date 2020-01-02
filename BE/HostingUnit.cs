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
        public int capacityAdults;
        public int capacityChildren;
        public Host Owner=new Host();
        public string HostingUnitName;
        public bool[,] Diary=new bool[12,31];
        public bool occupied = false;
        public double pricePerDayPerAdult;
        public double pricePerDayPerChild;
        public int succesfulDeals;
        public bool pool;
        public bool garden;
        public bool jacuzzi;
        public bool childrenAttraction;
        public BE.Area area;
        public override string ToString()
        {
            string str = "";
            str += "HostingUnit Key: " + HostingUnitKey;
            str += Owner.ToString();
            str += "\nHostingUnit Name:" + HostingUnitName;
            str += "\nPrice per day for each adult: " + pricePerDayPerAdult;
            str += "\nPrice per day for each child: " + pricePerDayPerChild;
            str += "\nnumber of succesful deals: " + succesfulDeals;
            return str;
        }
    }
}

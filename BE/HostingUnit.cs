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
        public int capacityAdults { get; set; }
        public int capacityChildren { get; set; }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        public string address { get; set; }
        public bool[,] Diary { get; set; }
        public bool occupied { get; set; }
        public double pricePerDayPerAdult { get; set; }
        public double pricePerDayPerChild { get; set; }
        public int succesfulDeals { get; set; }
        public bool pool { get; set; }
        public bool garden { get; set; }
        public bool jacuzzi { get; set; }
        public bool childrenAttraction { get; set; }
        public BE.Area area { get; set; }
        public HostingUnit()
        {
            HostingUnitKey = Configuration.StaticHostingUnitKey++;
            Owner = new Host();
            Diary = new bool[12, 31];
        }
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

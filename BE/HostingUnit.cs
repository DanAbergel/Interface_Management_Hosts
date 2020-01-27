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
        public BE.theType type { get; set; }
        public HostingUnit()
        {
            HostingUnitKey = Configuration.StaticHostingUnitKey++;
            Owner = new Host();
            Diary = new bool[12, 31];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    Diary[i, j] = true;
        }
        public override string ToString()
        {
            string str = "";
            str += "HostingUnit Key:  " + HostingUnitKey;
            str += Owner.ToString();
            str += "\nHostingUnit Name:" + HostingUnitName+"\n";
            str += "\nType of HostingUnit: " + type.ToString()+"\n";
            if(BE.Area.Center==area)
            str+="Area: Center";
            if(BE.Area.Jerusalem == area)
            str += "Area: Jerusalem";
            if(BE.Area.North == area)
            str += "Area: North"; 
            if(BE.Area.South == area)
            str += "Area: South";
            if (pool || garden || jacuzzi || childrenAttraction)
                str += "\nThe HostingUnit contents: ";
            if (pool)
                str += "   Pool";
            if (garden)
                str += "\n\t\t\tGarden";
            if (jacuzzi)
                str += "\n\t\t\tJacuzzi";
            if (childrenAttraction)
                str += "\n\t\tAttractions for children";
            str += "\nPrice per day for each adult:  " + pricePerDayPerAdult;
            str += "\nPrice per day for each child:  " + pricePerDayPerChild;
            str += "\nnumber of succesful deals:  " + succesfulDeals;
            return str;
        }
    }
}

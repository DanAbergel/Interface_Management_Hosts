using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.BE;

namespace BE
{
    public class GuestRequest
    {

        public GuestRequest()
        {
            client = new Client();
            guestRequestKey = Configuration.StaticGuestRequestKey++;
            RegistrationDate = DateTime.Now;
            StatusOfRequest = StatutRequirement.Active;
        }
        public long guestRequestKey;
        public Client client { get; set; }
        public StatutRequirement StatusOfRequest { get; set; }
        public bool canChangeStatusOfRequirement { get; set; }
        public DateTime RegistrationDate;
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Area area { get; set; }
        public string SubArea { get; set; }
        public theType type { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int totalVacationers { get; set; }
        public Criterion Pool { get; set; }
        public Criterion Jacuzzi { get; set; }
        public Criterion Garden { get; set; }
        public Criterion ChildrenAttractions { get; set; }

        public override string ToString()
        {
            string str = "";
            str += "GuestRequest Key" + guestRequestKey+"\n";
            str += client.ToString();
            str += "\nThe request is from "+EntryDate.Day+"/"+EntryDate.Month+"/"+EntryDate.Year ;
            str += " to " + ReleaseDate.Day + "/" + ReleaseDate.Month + "/" + ReleaseDate.Year;
            str += " for " + Adults + " adults and " + Children + " childrens\n";
            str += (Pool.ToString() == "Necessary") ? "necessary with a pool\n" : "";
            str += (Pool.ToString() == "Possible") ? "possible with a pool\n" : "";
            str += (Jacuzzi.ToString() == "Necessary") ? "necessary with a jacuzzi\n" : "";
            str += (Jacuzzi.ToString() == "Possible") ? "possible with a jacuzzi\n" : "";
            str += (Garden.ToString() == "Necessary") ? "necessary with a garden\n" : "";
            str += (Garden.ToString() == "Possible") ? "possible with a garden\n" : "";
            str += (ChildrenAttractions.ToString() == "necessary") ? "necessary with a pool\n" : "";
            str += (ChildrenAttractions.ToString() == "possible") ? "possible with a pool\n" : "";
            return str;
        }
    }
}

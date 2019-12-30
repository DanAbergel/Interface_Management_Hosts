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
        public long guestRequestKey= Configuration.StaticGuestRequestKey++;
        public Client client;
        public StatutRequirement StatusOfRequest;
        public bool canChangeStatusOfRequirement;
        public DateTime RegistrationDate;
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public Area area;
        public string SubArea;
        public theType type;
        public int Adults;
        public int Children;
        public Criterion Pool;
        public Criterion Jacuzzi;
        public Criterion Garden;
        public Criterion ChildrenAttractions;
        
        public override string ToString()
        {
            string str = " ";
            str += client.ToString();
            str += "\nThe request is from " + EntryDate + " to " + ReleaseDate;
            str += "for " + Adults + " adults and " + Children + "childrens\n";
            str += (Pool.ToString() == "Necessary") ? "necessary with a pool\n" : "";
            str += (Pool.ToString() == "Possible") ? "possible with a pool\n" : "";
            str += (Jacuzzi.ToString() == "Necessary") ? "necessary with a jacuzzi\n" : "";
            str += (Jacuzzi.ToString() == "Possible") ? "possible with a jacuzzi\n" : "";
            str += (Garden.ToString() == "Necessary") ? "with a garden\n" : "";
            str += (Garden.ToString() == "Possible") ? "with a garden\n" : "";
            str += (ChildrenAttractions.ToString() == "Necessary") ? "necessary with a pool\n" : "";
            str += (ChildrenAttractions.ToString() == "Possible") ? "possible with a pool\n" : "";
            return str;
        }
    }
}

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
        public string PrivateName;
        public string FamilyName;
        public string MailAddress;
        public StatutRequirement StatusOfRequest;
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
        

        
        //ctor
        internal GuestRequest(string PrivateName, string FamilyName, string MailAddress, StatutRequirement Status, DateTime RegistrationDate, DateTime EntryDate, DateTime ReleaseDate, Area area, string SubArea, theType type, int Adults, int Children, Criterion Pool, Criterion Jacuzzi, Criterion Garden, Criterion ChildrenAttractions)
        {
            this.PrivateName = PrivateName;
            this.FamilyName = FamilyName;
            this.MailAddress = MailAddress;
            this.StatusOfRequest = Status;
            this.RegistrationDate = RegistrationDate;
            this.EntryDate = EntryDate;
            this.ReleaseDate = ReleaseDate;
            this.area = area;
            this.SubArea = SubArea;
            this.type = type;
            this.Adults = Adults;
            this.Children = Children;
            this.Pool = Pool;
            this.Jacuzzi = Jacuzzi;
            this.Garden = Garden;
            this.ChildrenAttractions = ChildrenAttractions;
        }
        public override string ToString()
        {
            string str = " ";
            str += "guestRequestKey" + guestRequestKey;
            str += "\nname:" + PrivateName + " " + FamilyName;
            str += "\nMail:" + MailAddress;
            str += "The request is from " + EntryDate + " to " + ReleaseDate;
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

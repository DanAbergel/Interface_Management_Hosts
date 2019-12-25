using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest:BE
    {
        private int guestRequestKey;
        static private int sourceKey = 1000000;
        private string PrivateName;
        private string FamilyName;
        private string MailAddress;
        private string Status;
        private DateTime RegistrationDate;
        private DateTime EntryDate;
        private DateTime ReleaseDate;
        private Area area;
        private string SubArea;
        private Type type;
        private int Adults;
        private int Children;
        private Criterion Pool;
        private Criterion Jacuzzi;
        private Criterion Garden;
        private Criterion ChildrenAttractions;

        //ctor
        internal GuestRequest(int guestRequestKey, string PrivateName, string FamilyName, string MailAddress, string Status, DateTime RegistrationDate, DateTime EntryDate, DateTime ReleaseDate, Area area, string SubArea, Type type, int Adults, int Children, Criterion Pool, Criterion Jacuzzi, Criterion Garden, Criterion ChildrenAttractions)
        {

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

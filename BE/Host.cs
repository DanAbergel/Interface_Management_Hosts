using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public long HostKey = Configuration.StaticHostKey++;
        public string PrivateName;
        public string FamilyName;
        public long PhoneNumber;
        public string MailAddress;
        public BankBranch Account;
        public bool CollectionClearance;
        public int numOfHostingUnit;

        public override string ToString()
        {
            string str = "";
            str += "Name of Host: " + PrivateName + " " + FamilyName;
            str += "Mail: " + MailAddress + "Phone number: " + PhoneNumber;
            return str;
        }
        
       
    }
 }
    
        
        
    


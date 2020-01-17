using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public string ID;
        public string PrivateName;
        public string FamilyName;
        public string PhoneNumber;
        public string MailAddress;
        public BankBranch Account=new BankBranch();
        public bool CollectionClearance;
        public int numOfHostingUnit;
        public override string ToString()
        {
            string str = "";
            str += "\nName of Host: " + PrivateName + " " + FamilyName;
            str += "\nMail: " + MailAddress + "\nPhone number: " + PhoneNumber;
            return str;
        }
        
       
    }
    }
    
        
        
    


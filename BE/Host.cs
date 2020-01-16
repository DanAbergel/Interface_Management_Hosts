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
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public BankBranch Account=new BankBranch();
        public bool CollectionClearance { get; set; }
        public int numOfHostingUnit { get; set; }
        public override string ToString()
        {
            string str = "";
            str += "\nName of Host: " + PrivateName + " " + FamilyName;
            str += "\nMail: " + MailAddress + "\nPhone number: " + PhoneNumber;
            return str;
        }
        
       
    }
    }
    
        
        
    


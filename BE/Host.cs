using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public string ID { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public BankBranch Account { get; set; }
        public bool CollectionClearance { get; set; }
        public int numOfHostingUnit { get; set; }
        public Host()
        {
            Account = new BankBranch();
        }
        public override string ToString()
        {
            string str = "";
            str += "\nName of Host: " + PrivateName + " " + FamilyName;
            str += "\nMail: " + MailAddress + "\nPhone number: " + PhoneNumber;
            return str;
        }
        
       
    }
    }
    
        
        
    


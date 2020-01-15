using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Client
    {
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public string NumberPhone { get; set; }
        public BankBranch bank;
        public override string ToString()
        {
            string str="";
            str += "Name of Client: " + PrivateName + " " + FamilyName;
            str += "\nMail: " + MailAddress + "\nPhone number: " + NumberPhone;
            return str;
        }
    }
}

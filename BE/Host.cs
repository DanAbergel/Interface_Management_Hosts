using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        internal long HostKey { get; }
        internal string PrivateName { get; set; }
        internal string FamilyName { get; set; }
        internal long PhoneNumber { get; set; }
        internal string MailAddress { get; set; }
        internal BankAccount Account { get; set; }
        internal bool CollectionClearance { get; set; }

        //ctor
        public Host(long HostKey,string PrivateName,string FamilyName,long PhoneNumber,string MailAddress, BankAccount Account,bool Collectionlearance)
        {
            this.HostKey = HostKey;
            this.PrivateName = PrivateName;
            this.FamilyName = FamilyName;
            this.PhoneNumber = PhoneNumber;
            this.MailAddress = MailAddress;
            this.Account = Account;
            this.CollectionClearance = CollectionClearance;
            
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

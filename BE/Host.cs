using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Host
    {
        public long HostKey= Configuration.StaticHostKey++;
        public string PrivateName;
        public string FamilyName;
        public long PhoneNumber;
        public string MailAddress;
        public BankBranch Account;
        public bool CollectionClearance;

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

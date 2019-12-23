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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.BE;

namespace BE
{
    public class Order
    {
        public long HostingUnitKey { get; set; }
        public long GuestRequestKey { get; set; }
        public long OrderKey { get; set; }
        public Status status { get; set; }
        public DateTime OrderDate { get; set; }
        public HostingUnit hostingUnitReserved { get; set; }
        public GuestRequest guestRequest { get; set; }
        public double TotalPrice { get; set; }
        public DateTime lastModification { get; set; }

        public Order()
        {
            status = Status.NotYetAddressed;//valeur par defaut
        }

        public override string ToString()
        {
            string str = "";
            str += "Hosting Unit Key: " + HostingUnitKey;
            str += "\nGuest Request Key: " + GuestRequestKey;
            str += "\nOrder Key: " + OrderKey;
            str += hostingUnitReserved.ToString();
            str += "\nStatus: " + status;
            str += "\nOrderDate: " + OrderDate + "\n";
            return str;
        }
    }
}

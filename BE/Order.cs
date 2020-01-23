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
       
        public long OrderKey { get; set; }
        public Status status { get; set; }
        public DateTime OrderDate { get; set; }
        public HostingUnit hostingUnitReserved { get; set; }
        public GuestRequest guestRequest { get; set; }
        public double TotalPrice { get; set; }
        public DateTime lastModification { get; set; }

        public Order()
        {
            OrderKey = ++Configuration.StaticOrder;
            status = Status.NotYetAddressed;//valeur par defaut
            OrderDate =lastModification= DateTime.Now;
        }
        public override string ToString()
        {
            string str = "";
            str += "\nOrder Key:" + OrderKey;
            str += "\nOrderDate:" + OrderDate + "\n";
            str += "Details of HostingUnit reserved:\n";
            str += hostingUnitReserved.ToString();
            str += "The total price of your reservation is " + TotalPrice + " shequels\n";
            str += "We wish you good holidays !\n";
                return str;
        }
    }
}

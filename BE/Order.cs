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
        public long HostingUnitKey;
        private long GuestRequestKey;
        private long OrderKey;
        private Status status;
        private DateTime CreateDate;
        private DateTime OrderDate;

        //ctor
        internal Order(long HostingUnitKey, long GuestRequestKey,Status status, DateTime CreateDate, DateTime OrderDate)
        {
            this.HostingUnitKey = HostingUnitKey;
            this.GuestRequestKey = GuestRequestKey;
            this.OrderKey =Configuration.StaticOrder++;
            this.status = status;
            this.CreateDate = CreateDate;
            this.OrderDate = OrderDate;
        }

        public override string ToString()
        {
            string str = "";
            str += "Hosting Unit Key: " + HostingUnitKey;
            str += "\nGuest Request Key: " + GuestRequestKey;
            str += "\nOrder Key: " + OrderKey;
            str += "\nStatus: " + status;
            str += "\nCreateDate: " + CreateDate;
            str += "\nOrderDate: " + OrderDate + "\n";
            return str;
        }
    }
}

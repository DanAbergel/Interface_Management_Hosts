﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order:BE
    {
        private long HostingUnitKey;
        private long GuestRequestKey;
        private long OrderKey;
        private Status status;
        private DateTime CreateDate;
        private DateTime OrderDate;
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

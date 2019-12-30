﻿using System;
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
        public long GuestRequestKey;
        public long OrderKey;
        public Status status;
        public DateTime CreateDate;
        public DateTime OrderDate;
        public HostingUnit hostingUnitReserved;
        public Host hostofHostingUnitReserved;
        public Client client;
        public GuestRequest guestRequest;
        public double TotalPrice;
        
        
       

        public override string ToString()
        {
            string str = "";
            str += "Hosting Unit Key: " + HostingUnitKey;
            str += "\nGuest Request Key: " + GuestRequestKey;
            str += "\nOrder Key: " + OrderKey;
            str += hostofHostingUnitReserved.ToString()+"\n";
            str += client.ToString()+"\n";
            str += hostingUnitReserved.ToString();
            str += "\nStatus: " + status;
            str += "\nCreateDate: " + CreateDate;
            str += "\nOrderDate: " + OrderDate + "\n";
            return str;
        }
    }
}

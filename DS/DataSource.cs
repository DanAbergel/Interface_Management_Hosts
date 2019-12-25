using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DS
{


    public class DataSource
    {
        internal static List<HostingUnit> hostingUnits;
        internal static List<Order> orders;
        internal static List<GuestRequest> guestRequests;


        static DataSource()
        {
            hostingUnits = new List<HostingUnit>
            {
                    new HostingUnit(15, new Host(12345678,"Nathane","Baranes",0549524434,"nathaneb@hotmail.fr", new BankAccount(11,"דיסקונט",41,"210 יפו","ירושלים",165555),true) ,"chateau")
            };

            orders = new List<Order>
            {

            };

            guestRequests = new List<GuestRequest>
            {

            };


        }


    }



}

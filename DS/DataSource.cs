using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DS
{


    static public class DataSource
    {
        public static List<HostingUnit> hostingUnits;
        public static List<Order> orders;
        public static List<GuestRequest> guestRequests;
        public static List<BankAccount> allBankAccounts;
        public static List<string> allBanks={Hapoalim,Leumi,Mercantil,Yahav,Discount};
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

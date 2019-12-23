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
            internal static List<HostingUnit> hostingUnits = new List<BE.HostingUnit>();
            internal static List<Order> orders = new List<Order>();
            internal static List<GuestRequest> guestRequests = new List<GuestRequest>();


        static DataSource()
        {
            hostingUnits.Add(new HostingUnit()
            {
                HostingUnitKey = 55555555;
            owner = new Host();

            });
             }
            

        }
   





}

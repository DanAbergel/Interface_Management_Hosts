using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal interface IDAL
    {
             
        void addHostingUnit(HostingUnit hostingUnit);
        void deleteHostingUnit();
        void uptadeHostingUnit(HostingUnit updateHostingUnit);
        List<HostingUnit> getAllHostingUnits();
       
    

      

        void addGuestRequest(String id, String name, int age);
        void updateGuestRequest();
        List<GuestRequest> getAllGuestRequest();
   

      
        void addOrder(Order order);
        void updateOrder();
        List<Order> getAllOrders();
       

        List<BankAccount> GetAllBankAccounts();
    }
}

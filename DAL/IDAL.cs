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
        //fonctions logement    

        void addHostingUnit(HostingUnit hostingUnit);
        void deleteHostingUnit();
        void uptadeHostingUnit(HostingUnit updateHostingUnit);
        List<HostingUnit> getAllHostingUnits();
       
        //fonctions requete

        void addGuestRequest(String id, String name, int age);
        void updateGuestRequest();
        List<GuestRequest> getAllGuestRequest();
   
        //fonctions commande en cours
      
        void addOrder(Order order);
        void updateOrder();
        List<Order> getAllOrders();
       
        //liste des comptes bancaires

        List<BankAccount> GetAllBankAccounts();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        //fonctions logement    

        void addHostingUnit(HostingUnit hostingUnit);
        void deleteHostingUnit(long HostingUnitKey);
        void uptadeHostingUnit(HostingUnit updateHostingUnit);
        List<HostingUnit> getAllHostingUnits();
       
        //fonctions requete

        void addGuestRequest(GuestRequest guestRequest);
        void deleteGuestRequest(long guestRequestKey);
        void updateGuestRequest(GuestRequest updateGuestRequest);
        List<GuestRequest> getAllGuestRequest();
   
        //fonctions commande en cours
      
        void addOrder(Order order);
        void updateOrder(Order updateOrder);
        List<Order> getAllOrders();
       
        //liste des comptes bancaires

        List<BankBranch> GetAllBankAccounts();

        //liste des proprietaires

        List<Host> getAllHost();

        // fonction pour exceptions

        bool HostingUnitExist(long HostingUnitKey);
        bool GuestRequestExist(long guestRequestKey);
        bool OrderExist(long HostingUnitKey);


    }
}

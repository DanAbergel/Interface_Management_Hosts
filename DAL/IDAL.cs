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
        void deleteHostingUnit(string HostingUnitKey);
        void uptadeHostingUnit(HostingUnit updateHostingUnit);
        List<HostingUnit> getHostingUnits(Func<HostingUnit, bool> predicate = null);
        //List<HostingUnit> getAllHostingUnits();
        IEnumerable<BE.HostingUnit> getAllHostingUnits(Func<BE.HostingUnit, bool> predicate = null);
       

        //fonctions requete

        void addGuestRequest(GuestRequest guestRequest);
        void deleteGuestRequest(long guestRequestKey);
        void updateGuestRequest(GuestRequest updateGuestRequest);
        IEnumerable<BE.GuestRequest> getAllGuestRequest(Func<BE.GuestRequest, bool> predicate = null);

        //fonctions commande en cours

        void addOrder(Order order);
        void updateOrder(Order updateOrder);
        void deleteOrder(string orderKey);
        IEnumerable<BE.Order> getAllOrders(Func<BE.Order, bool> predicate = null);

        //liste des comptes bancaires

        IEnumerable<BE.BankBranch> GetAllBankAccounts(Func<BE.BankBranch, bool> predicate = null);

        //liste des proprietaires

        IEnumerable<BE.Host> getAllHost(Func<BE.Host, bool> predicate = null);

        // fonction pour exceptions

        bool HostingUnitExist(string HostingUnitKey);
        bool GuestRequestExist(long guestRequestKey);
        bool OrderExist(string OrderKey);

        HostingUnit GetHostingUnitByID(string HostingUnitKey);
        GuestRequest GetGuestRequestByID(long ID);
        Order GetOrderByID(string OrderKey);


    }
}

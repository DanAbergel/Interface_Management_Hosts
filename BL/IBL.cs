using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    { 

            #region fonctions logement    

            void addHostingUnit(HostingUnit hostingUnit);
            void deleteHostingUnit(long HostingUnitKey);
            void uptadeHostingUnit(HostingUnit updateHostingUnit);
            List<HostingUnit> getAllHostingUnits();
            HostingUnit GetHostingUnitByID(long ID);
            List<HostingUnit> getHostingUnits(GuestRequest guestRequest);


        #endregion

            #region fonctions requete

            void addGuestRequest(GuestRequest guestRequest);
            void deleteGuestRequest(long guestRequestKey);
            void updateGuestRequest(GuestRequest updateGuestRequest);
            List<GuestRequest> getAllGuestRequest();
            GuestRequest GetGuestRequestByID(long ID);
            #endregion

            #region fonctions commande en cours

            void addOrder(Order order);
            void updateOrder(Order updateOrder);
            Order calculateTotalPriceWithComission(Order order);
            List<Order> getAllOrders();

            #endregion

            #region liste des comptes bancaires

            List<BankBranch> GetAllBankAccounts();

            #endregion
    
            #region fonction grouping

            IEnumerable<IGrouping<BE.BE.Area,GuestRequest>> GetRequestByArea();
            IEnumerable<IGrouping<int, GuestRequest>> GetRequestByTotalVacationers();
            IEnumerable<IGrouping<int, Host>> GetHostByNumOfHostingUnit(bool sorted= false);
            IEnumerable<IGrouping<BE.BE.Area, HostingUnit>> GetHostingUnitByArea();

            #endregion
        
    }
}




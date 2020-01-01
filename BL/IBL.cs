using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    interface IBL
    { 

            #region fonctions logement    

            void addHostingUnit(HostingUnit hostingUnit);
            void deleteHostingUnit(long HostingUnitKey);
            void uptadeHostingUnit(HostingUnit updateHostingUnit);
            List<HostingUnit> getAllHostingUnits();
            
            #endregion
            
            #region fonctions requete

            void addGuestRequest(GuestRequest guestRequest);
            void deleteGuestRequest(long guestRequestKey);
            void updateGuestRequest(GuestRequest updateGuestRequest);
            List<GuestRequest> getAllGuestRequest();
            #endregion

            #region fonctions commande en cours

            void addOrder(Order order);
            void updateOrder(Order updateOrder);
            List<Order> getAllOrders();

            #endregion

            #region liste des comptes bancaires

            List<BankBranch> GetAllBankAccounts();

            #endregion
    
            #region fonction grouping

            IEnumerable<IGrouping<BE.BE.Area, BE.GuestRequest>> GetRequestByArea();
            IEnumerable<IGrouping<int, BE.GuestRequest>> GetRequestByTotalVacationers();
            IEnumerable<IGrouping<long, BE.Host>> GetHostByNumOfHostingUnit(bool sorted = false);
            IEnumerable<IGrouping<BE.BE.Area, BE.HostingUnit>> GetHostingUnitByArea();

            #endregion
        
    }
}




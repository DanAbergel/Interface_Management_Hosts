﻿using System;
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
            void deleteHostingUnit(string HostingUnitKey);
            void uptadeHostingUnit(HostingUnit updateHostingUnit);
            //List<HostingUnit> getAllHostingUnits();
            List<HostingUnit> getHostingUnits(GuestRequest guestRequest);
            List<HostingUnit> getHostingUnits(Func<HostingUnit, bool> p);
            HostingUnit GetHostingUnitByID(long ID);
            IEnumerable<BE.HostingUnit> getAllHostingUnits(Func<BE.HostingUnit, bool> predicate = null);


        #endregion

        #region fonctions requete

             void addGuestRequest(GuestRequest guestRequest);
            void deleteGuestRequest(long guestRequestKey);
            void updateGuestRequest(GuestRequest updateGuestRequest);
             IEnumerable<BE.GuestRequest> getAllGuestRequest(Func<BE.GuestRequest, bool> predicate = null);
            GuestRequest GetGuestRequestByID(long ID);
            #endregion

            #region fonctions commande en cours

            void addOrder(Order order);
            void updateOrder(Order updateOrder);
            IEnumerable<BE.Order> getAllOrders(Func<BE.Order, bool> predicate = null);

        #endregion

        #region liste des comptes bancaires

        IEnumerable<BE.BankBranch> GetAllBankAccounts(Func<BE.BankBranch, bool> predicate = null);

        #endregion

        #region fonction grouping

        IEnumerable<IGrouping<BE.BE.Area,GuestRequest>> GetRequestByArea();
            IEnumerable<IGrouping<int, GuestRequest>> GetRequestByTotalVacationers();
            IEnumerable<IGrouping<int, Host>> GetHostByNumOfHostingUnit(bool sorted= false);
            IEnumerable<IGrouping<BE.BE.Area, HostingUnit>> GetHostingUnitByArea();

            #endregion
        
    }
}




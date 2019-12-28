using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    class BL_imp : IBL
    {
        DAL.IDAL newDal;
        public BL_imp()//CTOR
        {
            newDal = DAL.FactoryAndSingletonDal.GetDAL();
        }



        ///////////////////////////////////////////////////toutes les fonctions implementees de IBL///////////////////////////////////////////
        //fonctions de Hosting Unit
         public void addHostingUnit(HostingUnit hostingUnit)
        {

        }
        public void deleteHostingUnit(long HostingUnitKey)
        {

        }
        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {

        }
        public List<HostingUnit> getAllHostingUnits()
        {
            return new List<HostingUnit>();
        }

        //fonctions requete

        public void addGuestRequest(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate.CompareTo(guestRequest.ReleaseDate) > 0)
                throw new Exception("Error !!! Entry date is later than release date ");
            if (guestRequest.EntryDate.CompareTo(guestRequest.ReleaseDate) == 0)
                throw new Exception("Error !!! We accept only with at least one day between Entry and Release dates");

        }
        public void deleteGuestRequest(long guestRequestKey)
        {

        }
        public void updateGuestRequest(GuestRequest updateGuestRequest)
        {

        }
        public List<GuestRequest> getAllGuestRequest()
        {
            return new List<GuestRequest>();
        }

        //fonctions commande en cours

        public void addOrder(Order order)
        {

        }
        public void updateOrder(Order updateOrder)
        {

        }
        public List<Order> getAllOrders()
        {
            return new List<Order>();
        }

        //liste des comptes bancaires

        public List<BankBranch> GetAllBankAccounts()
        {
            return new List<BankBranch>();
        }

    }
}

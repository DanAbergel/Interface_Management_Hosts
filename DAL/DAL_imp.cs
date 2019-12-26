using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    internal class DAL_imp : IDAL
    {
        //Factory Method
        public DAL_imp()
        {

        }


        //toutes les fonctions de rajout//
        public void addGuestRequest(GuestRequest guestRequest)
        {
            DataSource.guestRequests.Add(guestRequest);
        }

        public void addHostingUnit(HostingUnit hostingUnit)
        {
            DataSource.hostingUnits.Add(hostingUnit);
        }

        public void addOrder(Order order)
        {
            DataSource.orders.Add(order);
        }

        //toutes les fonctions de supression//
        public void deleteHostingUnit(long HostingUnitKey)
        {
            HostingUnit deletedHostingUnit = (from HostingUnit in DataSource.hostingUnits
                          where HostingUnit.HostingUnitKey == HostingUnitKey
                          select HostingUnit).First();
            if (deletedHostingUnit == null)
                throw new Exception("Error in try of delete a hosting unit");
            DataSource.hostingUnits.Remove(deletedHostingUnit);

        }
        public void deleteGuestRequest(long guestRequestKey) 
        {
            GuestRequest deletedGuestRequest = (from GuestRequest in DataSource.guestRequests
                                      where GuestRequest.guestRequestKey == guestRequestKey
                                      select GuestRequest).First();
            if (deletedGuestRequest == null)
                throw new Exception("Error in try of delete a guest request");
            DataSource.guestRequests.Remove(deletedGuestRequest);
        }
        public List<BankAccount> GetAllBankAccounts()
        {
            return new List<BankAccount>(DataSource.allBankAccounts);
        }

        public List<GuestRequest> getAllGuestRequest()
        {
            return new List<GuestRequest>(DataSource.guestRequests);
        }

        public List<HostingUnit> getAllHostingUnits()
        {
            return new List<HostingUnit>(DataSource.hostingUnits);
        }

        public List<Order> getAllOrders()
        {
            return new List<Order>(DataSource.orders);
        }

        public void updateGuestRequest(GuestRequest updateGuestRequest)
        {
            var updatedGuestRequest = (from GuestRequest in DataSource.guestRequests
                          where GuestRequest.guestRequestKey == updateGuestRequest.guestRequestKey
                          select GuestRequest).First();
            if (updatedGuestRequest == null)
                throw new Exception("Error in try of update a guest request");
            DataSource.guestRequests.Remove(updatedGuestRequest);
            DataSource.guestRequests.Add(updateGuestRequest);
        }

        public void updateOrder(Order updateOrder)
        {
            var updatedOrder = (from Order in DataSource.orders
                          where Order.HostingUnitKey == updateOrder.HostingUnitKey
                          select Order).First();
            if (updatedOrder == null)
                throw new Exception("Error in try of update an order");
            DataSource.orders.Remove(updatedOrder);
            DataSource.orders.Add(updateOrder);
        }

        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {
            var updatedHostingUnit = (from HostingUnit in DataSource.hostingUnits
                          where HostingUnit.HostingUnitKey == updateHostingUnit.HostingUnitKey
                          select HostingUnit).First();
            if(updatedHostingUnit==null)
                throw new Exception("Error in try of update a hosting unit");
            DataSource.hostingUnits.Remove(updatedHostingUnit);
            DataSource.hostingUnits.Add(updateHostingUnit); 
        }



    }
}

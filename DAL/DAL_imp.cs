using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    internal class DAL_imp:IDAL
    {
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

        public void deleteHostingUnit(long HostingUnitKey)
        {
            var result = (from HostingUnit in DataSource.hostingUnits
                          where HostingUnit.HostingUnitKey == HostingUnitKey
                          select HostingUnit).First();
            DataSource.hostingUnits.Remove(result);

        }

        public List<BankAccount> GetAllBankAccounts()
        {
            throw new NotImplementedException();
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
            var result = (from GuestRequest in DataSource.guestRequests
                          where GuestRequest.guestRequestKey == updateGuestRequest.guestRequestKey
                          select GuestRequest).First();
            DataSource.guestRequests.Remove(result);
            DataSource.guestRequests.Add(updateGuestRequest);
        }

        public void updateOrder(Order updateOrder)
        {
            var result = (from Order in DataSource.orders
                          where Order.HostingUnitKey == updateOrder.HostingUnitKey
                          select Order).First();
            DataSource.orders.Remove(result);
            DataSource.orders.Add(updateOrder);
        }

        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {
            var result = (from HostingUnit in DataSource.hostingUnits
                          where HostingUnit.HostingUnitKey == updateHostingUnit.HostingUnitKey
                          select HostingUnit).First();
            DataSource.hostingUnits.Remove(result);
            DataSource.hostingUnits.Add(updateHostingUnit);
        }


       
}

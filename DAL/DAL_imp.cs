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
        public void addGuestRequest(GuestRequest guestRequest)
        {
            DataSource.guestRequests.Add(guestRequest);
        }

        public void addHostingUnit(HostingUnit hostingUnit)
        {
            if (!HostingUnitExist(hostingUnit.HostingUnitKey))
            {
                DataSource.hostingUnits.Add(hostingUnit);
            }
            else
                throw new KeyNotFoundException("le logement existe deja");

        }

        public void addOrder(Order order)
        {
            DataSource.orders.Add(order);
        }

        public void deleteHostingUnit(long HostingUnitKey)
        {
            if (HostingUnitExist(HostingUnitKey))
            {
                var result = (from HostingUnit in DataSource.hostingUnits
                              where HostingUnit.HostingUnitKey == HostingUnitKey
                              select HostingUnit).First();
                if (!DataSource.hostingUnits.Remove(result))
                    throw new Exception("la supression n'a pas été éffectuée");//regardes ca
            }
            else
                throw new KeyNotFoundException("le logement n'existe pas");

        }

        public List<BankBranch> GetAllBankAccounts()
        {
            return new List<BankBranch>(DataSource.allBankAccounts);
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
            if (GuestRequestExist(updateGuestRequest.guestRequestKey))
            {
                var result = (from GuestRequest in DataSource.guestRequests
                              where GuestRequest.guestRequestKey == updateGuestRequest.guestRequestKey
                              select GuestRequest).First();
                DataSource.guestRequests.Remove(result);
                DataSource.guestRequests.Add(updateGuestRequest);
            }
            else
                throw new KeyNotFoundException("la requete n existe pas");
        }

        public void updateOrder(Order updateOrder)
        {
            if (OrderExist(updateOrder.HostingUnitKey))
            {
                var result = (from Order in DataSource.orders
                              where Order.HostingUnitKey == updateOrder.HostingUnitKey
                              select Order).First();
                DataSource.orders.Remove(result);
                DataSource.orders.Add(updateOrder);
            }
            else
                throw new KeyNotFoundException("aucune commande n'a ete trouve");
        }

        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {
            if (HostingUnitExist(updateHostingUnit.HostingUnitKey))
            {
                var result = (from HostingUnit in DataSource.hostingUnits
                              where HostingUnit.HostingUnitKey == updateHostingUnit.HostingUnitKey
                              select HostingUnit).First();
                DataSource.hostingUnits.Remove(result);
                DataSource.hostingUnits.Add(updateHostingUnit);
            }
            else
                throw new KeyNotFoundException("le logement n'est pas existant");
        }



        public bool HostingUnitExist(long HostingUnitKey)
        {
            HostingUnit tmp = (from HostingUnit in DataSource.hostingUnits
                               where HostingUnit.HostingUnitKey == HostingUnitKey
                               select HostingUnit).FirstOrDefault();
            if (tmp == default(HostingUnit))
                return false;
            else
                return true;
        }

        public bool GuestRequestExist(long guestRequestKey)
        {
            GuestRequest tmp = (from GuestRequest in DataSource.guestRequests
                                where GuestRequest.guestRequestKey == guestRequestKey
                                select GuestRequest).FirstOrDefault();
            if (tmp == default(GuestRequest))
                return false;
            else
                return true;

        }

        public bool OrderExist(long HostingUnitKey)
        {
            Order tmp = (from Order in DataSource.orders
                         where Order.HostingUnitKey == HostingUnitKey
                         select Order).FirstOrDefault();
            if (tmp == default(Order))
                return false;
            else
                return true;

        }

    }

}

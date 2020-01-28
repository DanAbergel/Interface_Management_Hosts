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
            if (!GuestRequestExist(guestRequest.guestRequestKey))
            {
                DataSource.guestRequests.Add(guestRequest.Clone());
            }

            else
                throw new KeyNotFoundException("la requete existe deja");


        }

        public void addHostingUnit(HostingUnit hostingUnit)
        {
            if (!HostingUnitExist(hostingUnit.HostingUnitKey))
            {
                DataSource.hostingUnits.Add(hostingUnit.Clone());
                hostingUnit.Owner.numOfHostingUnit++;
            }
            else
                throw new KeyNotFoundException("le logement existe deja");

        }

        public void addOrder(Order order)
        {
            DataSource.orders.Add(order.Clone());
        }

        public void deleteHostingUnit(string HostingUnitKey)
        {
            //verifie si le logement existe pour pouvoir le supprimer
            if (HostingUnitExist(HostingUnitKey))
            {
                var result = (from HostingUnit in DataSource.hostingUnits
                              where HostingUnit.HostingUnitKey == HostingUnitKey
                              select HostingUnit).First();
                DataSource.hostingUnits.Remove(result);

            }
            else//si il ne le trouve pas 
                throw new KeyNotFoundException("le logement n'existe pas");

        }

        public void deleteOrder(string orderKey)
        {
            if (OrderExist(orderKey))
            {
                var result = (from Order in DataSource.orders
                              where Order.OrderKey == orderKey
                              select Order).First();
                DataSource.orders.Remove(result);
            }
            else
                throw new KeyNotFoundException("la commande n'existe pas");

        }

        public void deleteGuestRequest(long guestRequestKey)
        {
            var result = from guestRequest in DataSource.guestRequests
                         where guestRequest.guestRequestKey == guestRequestKey
                         select guestRequest;
            if (!DataSource.guestRequests.Remove(result.ElementAt(0)))
                throw new KeyNotFoundException("Error!!!didnt find this GuestRequestKey");
        }
        public IEnumerable<BE.GuestRequest> getAllGuestRequest(Func<BE.GuestRequest, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.guestRequests.AsEnumerable().Select(t => t.Clone());
            return DataSource.guestRequests.Where(predicate).Select(t => t.Clone());
        }

        public IEnumerable<BE.HostingUnit> getAllHostingUnits(Func<BE.HostingUnit, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.hostingUnits.AsEnumerable().Select(t => t.Clone());
            return DataSource.hostingUnits.Where(predicate).Select(t => t.Clone());
        }

        public IEnumerable<BE.Order> getAllOrders(Func<BE.Order, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.orders.AsEnumerable().Select(t => t.Clone());
            return DataSource.orders.Where(predicate).Select(t => t.Clone());
        }

        public IEnumerable<BE.Host> getAllHost(Func<BE.Host, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.hosts.AsEnumerable().Select(t => t.Clone());
            return DataSource.hosts.Where(predicate).Select(t => t.Clone());
        }

        public IEnumerable<BE.BankBranch> GetAllBankAccounts(Func<BE.BankBranch, bool> predicate = null)
        {
            if (predicate == null)
                return DataSource.allBankAccounts.AsEnumerable().Select(t => t.Clone());
            return DataSource.allBankAccounts.Where(predicate).Select(t => t.Clone());
        }

        public void updateGuestRequest(GuestRequest updateGuestRequest)
        {
            if (GuestRequestExist(updateGuestRequest.guestRequestKey))
            {
                var result = (from GuestRequest in DataSource.guestRequests
                              where GuestRequest.guestRequestKey == updateGuestRequest.guestRequestKey
                              select GuestRequest).First();
                DataSource.guestRequests.Remove(result);
                DataSource.guestRequests.Add(updateGuestRequest.Clone());
            }
            else
                throw new KeyNotFoundException("la requete n existe pas");
        }

        public void updateOrder(Order updateOrder)
        {
            if (OrderExist(updateOrder.OrderKey))
            {
                var result = (from Order in DataSource.orders
                              where Order.OrderKey == updateOrder.OrderKey
                              select Order).First();
                DataSource.orders.Remove(result);
                DataSource.orders.Add(updateOrder.Clone());
            }
            else
                throw new KeyNotFoundException("aucune commande n'a été trouve");
        }

        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {
            if (HostingUnitExist(updateHostingUnit.HostingUnitKey))
            {
                var result = (from HostingUnit in DataSource.hostingUnits
                              where HostingUnit.HostingUnitKey == updateHostingUnit.HostingUnitKey
                              select HostingUnit).First();
                DataSource.hostingUnits.Remove(result);
                DataSource.hostingUnits.Add(updateHostingUnit.Clone());
            }
            else
                throw new KeyNotFoundException("le logement n'est pas existant");
        }



        public bool HostingUnitExist(string HostingUnitKey)
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

        public bool OrderExist(string OrderKey)
        {
            Order tmp = (from Order in DataSource.orders
                         where Order.OrderKey == OrderKey
                         select Order).FirstOrDefault();
            if (tmp == default(Order))
                return false;
            else
                return true;

        }


        public HostingUnit GetHostingUnitByID(string HostingUnitKey)
        {
            if (HostingUnitExist(HostingUnitKey))
            {
                return (from HostingUnit in DataSource.hostingUnits
                        where HostingUnit.HostingUnitKey == HostingUnitKey
                        select new HostingUnit()).FirstOrDefault();
            }
            throw new KeyNotFoundException("היחידה לא קיים");
        }

        public GuestRequest GetGuestRequestByID(long guestRequestKey)
        {
            if (GuestRequestExist(guestRequestKey))
            {
                return (from GuestRequest in DataSource.guestRequests
                        where GuestRequest.guestRequestKey == guestRequestKey
                        select new GuestRequest()).FirstOrDefault();
            }
            throw new KeyNotFoundException("הבקשה לא קיים");
        }

        public Order GetOrderByID(string OrderKey)
        {
            if (OrderExist(OrderKey))
            {
                return (from Order in DataSource.orders
                        where Order.OrderKey == OrderKey
                        select new Order()).FirstOrDefault();
            }
            throw new KeyNotFoundException("הזמנה לא קיימת");
        }

        public List<HostingUnit> getHostingUnits(Func<HostingUnit, bool> predicate = null)
        {
            return DataSource.hostingUnits.Where(predicate).Select(hu => (HostingUnit)hu.Clone()).ToList();
        }

    }

}

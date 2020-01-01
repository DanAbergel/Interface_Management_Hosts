using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;

namespace BL
{
    class BL_imp : IBL
    {
        IDAL newDal;
        public BL_imp()//CTOR
        {
            newDal = DAL.FactoryAndSingletonDal.GetDAL();
        }



        ///////////////////////////////////////////////////toutes les fonctions implementees de IBL///////////////////////////////////////////
        //fonctions de rajout
        public void addHostingUnit(HostingUnit hostingUnit)
        {
            //la verification de l'unicité du logement se fait en couche DAL
            if (!hostingUnit.Owner.CollectionClearance)
                throw new Exception("The host did not signed CollectionClearance !!!");
            hostingUnit.succesfulDeals = 0;
            newDal.addHostingUnit(hostingUnit);
        } 
        public void addGuestRequest(GuestRequest guestRequest)
        {
            if (differnceBetweenTwoDates(guestRequest.EntryDate,guestRequest.ReleaseDate) < 0)
                throw new Exception("Error !!! Entry date is later than release date ");
            if (guestRequest.EntryDate.CompareTo(guestRequest.ReleaseDate) == 0)
                throw new Exception("Error !!! We accept only with at least one day between Entry and Release dates");
            newDal.addGuestRequest(guestRequest);
        }
        public void addOrder(Order order)
        {
            //if (!SearchForFreeDates(order.guestRequest.EntryDate, order.guestRequest.ReleaseDate, order.hostingUnitReserved.Diary))
              //  throw new KeyNotFoundException("The demanded dates are not available for this hosting unit");
            newDal.addOrder(order);
        }



        ////implementation de supression
        public void deleteHostingUnit(long HostingUnitKey)
        {
            if (newDal.HostingUnitExist(HostingUnitKey))
            {
                //verifie si le logement est occuppé et si c'est le cas il ne peut pas le supprimer
                var result = from hostingUnit in newDal.getAllHostingUnits()
                             where hostingUnit.HostingUnitKey == HostingUnitKey
                             select hostingUnit;
                foreach (var item in result) ;
                if (!result.First().occupied)
                    newDal.deleteHostingUnit(HostingUnitKey);
            }
        }
        public void deleteGuestRequest(long guestRequestKey)
        {
            newDal.deleteGuestRequest(guestRequestKey);
        }

        ////implementation de mise a jour
        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {
            newDal.uptadeHostingUnit(updateHostingUnit);
        }
        public void updateGuestRequest(GuestRequest updateGuestRequest)
        {
           
            //!!!!//
        } 
        public void updateOrder(Order updateOrder)
        {
            //change la date d'actualisation
            updateOrder.lastModification = DateTime.Now;
            //seulement si le deal n'a pas été conclu je peux changer le statut de la demande
            if (updateOrder.guestRequest.canChangeStatusOfRequirement)
                newDal.updateOrder(updateOrder);
            if (updateOrder.guestRequest.StatusOfRequest == BE.BE.StatutRequirement.DealClosed)
            {
                updateOrder.guestRequest.canChangeStatusOfRequirement = false;
                updateOrder.hostingUnitReserved.succesfulDeals++;
                calculateTotalPriceWithComission(updateOrder);
                assignDatesForAHostingUnit(updateOrder.guestRequest.EntryDate, updateOrder.guestRequest.ReleaseDate, updateOrder.hostingUnitReserved);
            }
            //si le statut de la demande est closed jappelle la fonction deleteGuestRequest
            if (updateOrder.guestRequest.StatusOfRequest == BE.BE.StatutRequirement.Closed)
                deleteGuestRequest(updateOrder.guestRequest.guestRequestKey);
            //si le statut est que le mail a ete envoye j imprime le mail a l ecran
            if (updateOrder.status == BE.BE.Status.MailSent&&updateOrder.hostingUnitReserved.Owner.CollectionClearance)
                Console.WriteLine(updateOrder);
        }



        //implementation de retour de listes
        public List<HostingUnit> getAllHostingUnits()
        {
            return newDal.getAllHostingUnits();
        }
        public List<GuestRequest> getAllGuestRequest()
        {
            return newDal.getAllGuestRequest();
        }
        public List<Order> getAllOrders()
        {
            return newDal.getAllOrders();
        }
        public List<BankBranch> GetAllBankAccounts()
        {
            return newDal.GetAllBankAccounts();
        }





        ////autres fonctions
        public bool SearchForFreeDates(DateTime Entry, DateTime End, bool[,] Diary)
        {
            int daysInMonth = DateTime.DaysInMonth(Entry.Year, Entry.Month);
            for (int day = Entry.Day - 1; day < daysInMonth; day++)//verifie le premier mois de la requete
            {
                if (!Diary[Entry.Month - 1, day])//si il trouve un jour qui est occuppe il arrete la boucle et rend false
                    return false;
            }
            /*seulement si pour l instant il n a trouve aucun probleme il continue a verifier 
             les mois qui sont entre le mois du debut et le mois de la fin*/

            for (int month = Entry.Month; month < End.Month - 1; month++)
            {
                daysInMonth = DateTime.DaysInMonth(Entry.Year, month + 1);
                for (int day = 0; day < daysInMonth; day++)
                    if (!Diary[month, day])
                        return false;
            }

            /*seulement si pour l instant il n a trouve aucun probleme il continue a verifier 
            le dernier mois */
            daysInMonth = DateTime.DaysInMonth(Entry.Year, End.Month - 1);
            for (int day = 0; day < daysInMonth; day++)
            {
                if (!Diary[End.Month - 1, day])
                    return false;
            }
            /*si il n a pas retourne de false jusque maintenant ca veut dire qu'il n'y'a aucun probleme
             et donc il renvoie une valeur true qui signifie que les dates demandées sont valides */
            return true;
        }

        Order calculateTotalPriceWithComission(Order order)
        {
            double priceForsAdults,priceForChildrens,TotalComission;
            priceForsAdults = order.guestRequest.Adults * order.hostingUnitReserved.pricePerDayPerAdult;
            priceForChildrens = order.guestRequest.Children * order.hostingUnitReserved.pricePerDayPerChild;
            TotalComission = 10 * differnceBetweenTwoDates(order.guestRequest.EntryDate, order.guestRequest.ReleaseDate);
            order.TotalPrice=priceForsAdults+priceForChildrens+TotalComission;
            return order;
        }

        public IEnumerable<HostingUnit> SearchHostingUnitinList(DateTime Entry,int days)
        {
            DateTime End = Entry.AddDays(days);
            var newList = from HostingUnit in getAllHostingUnits()
                          where SearchForFreeDates(Entry, End, HostingUnit.Diary)
                          select HostingUnit;
            foreach (var item in newList) ;
            return newList;
        }

        //calcule la difference de dates entre la date d'aujourd'hui et une date de fin
        public int differnceBetweenTwoDates(DateTime End)
        {
            int difference=0;
            DateTime today = DateTime.Today;
            int daysInMonth;
            daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            for (int day = today.Day; day < daysInMonth; day++)
                difference++;
            for (int month = today.Month; month < End.Month; month++)
            {
                daysInMonth = DateTime.DaysInMonth(today.Year, month + 1);
                for (int day = 0; day < daysInMonth; day++)
                    difference++;
            }
            for (int day = 0; day < End.Day; day++)
                difference++;
            return difference;
        }
        //calcule la difference de dates avec une date de debut et une de fin
        public int differnceBetweenTwoDates(DateTime Begin ,DateTime End)
        {
            int difference = 0;
            int daysInMonth;
            daysInMonth = DateTime.DaysInMonth(Begin.Year, Begin.Month);
            for (int day = Begin.Day; day < daysInMonth; day++)
                difference++;
            for (int month = Begin.Month; month < End.Month; month++)
            {
                daysInMonth = DateTime.DaysInMonth(Begin.Year, month + 1);
                for (int day = 0; day < daysInMonth; day++)
                    difference++;
            }
            for (int day = 0; day < End.Day; day++)
                difference++;
            return difference;
        }

        public int succesfulDealsForHostingUnit(HostingUnit unit)
        {
            return unit.succesfulDeals;
        }

        public void assignDatesForAHostingUnit(DateTime Entry,DateTime Exit,HostingUnit unit)
        {
            int daysInMonth = DateTime.DaysInMonth(Entry.Year, Entry.Month);
            for (int day = Entry.Day - 1; day < daysInMonth; day++)
                unit.Diary[Entry.Month - 1, day] = true;
            for (int month = Entry.Month; month < Exit.Month; month++)
            {
                daysInMonth = DateTime.DaysInMonth(Entry.Year, month);
                for (int day = 0; day < daysInMonth; day++)
                    unit.Diary[month, day] = true;
            }
            for (int day = 0; day < Exit.Day; day++)
                unit.Diary[Exit.Month - 1, day] = true;
        }
        public List<Order> updatesOrderFromDate(int days)
        {
            List<Order> listTmp=new List<Order>();
            int index = 0;
            DateTime firstDate = DateTime.Today.AddDays(-days);
            var newList = from order in newDal.getAllOrders()
                          where order.lastModification >= firstDate
                          select order;
            foreach (var order in newList) {
                listTmp.Add(newList.ElementAt(index++));
             }
            return listTmp;
        }

        public List<List<GuestRequest>>newGroupingPerArea()
        {
            List<List<GuestRequest>> TotalGrouping = new List<List<GuestRequest>>();
            var newGroup = from guestRequest in newDal.getAllGuestRequest()
                           group guestRequest by guestRequest.area into groups
                           orderby groups.ElementAt(0)
                         select groups;
            foreach(var group in newGroup )
            {
                List<GuestRequest> Group = new List<GuestRequest>();
                foreach(var item in group)
                {
                    Group.Add(item);
                }
                TotalGrouping.Add(Group);
            }
            return TotalGrouping;
               
        }











       public IEnumerable<IGrouping<BE.BE.Area, BE.GuestRequest>> GetRequestByArea()
       {
             return from guestRequest in newDal.getAllGuestRequest()
                        group guestRequest by GuestRequest.area into f1
                        select f1;
       }

       public IEnumerable<IGrouping<int, BE.GuestRequest>> GetRequestByTotalVacationers()
       {
            return from GuestRequest in newDal.getAllGuestRequest()
                   group GuestRequest by GuestRequest.totalVacationers into f1
                   select f1;
       }

       public IEnumerable<IGrouping<int, BE.Host>> GetHostByNumOfHostingUnit()
       {
            return from host in newDal.getAllHost()
                   group host by host.numOfHostingUnit into f1
                   select f1;
       }


        public IEnumerable<IGrouping<BE.BE.Area, BE.HostingUnit>> GetHostingUnitByArea()
        {
            return from HostingUnit in newDal.getAllHostingUnits()
                   group HostingUnit by HostingUnit.area into f1
                   select f1;
        }    
    }
}
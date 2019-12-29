using System;
using System.Collections.Generic;
using System.Linq;
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
        //fonctions de rajout
        public void addHostingUnit(HostingUnit hostingUnit)
        {
            //la verification de l'unicité du logement se fait en couche DAL
            newDal.addHostingUnit(hostingUnit);
        } 
        public void addGuestRequest(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate.CompareTo(guestRequest.ReleaseDate) > 0)
                throw new Exception("Error !!! Entry date is later than release date ");
            if (guestRequest.EntryDate.CompareTo(guestRequest.ReleaseDate) == 0)
                throw new Exception("Error !!! We accept only with at least one day between Entry and Release dates");
            newDal.addGuestRequest(guestRequest);
        }
        public void addOrder(Order order)
        {
            //verifie si le proprietaire a rempli le certificat du compte en banque
            if (!order.hostofHostingUnitReserved.CollectionClearance)
                throw new KeyNotFoundException("The host did not signed CollectionClearance !!!");
            if (!SearchForFreeDates(order.guestRequest.EntryDate, order.guestRequest.ReleaseDate, order.hostingUnitReserved.Diary))
                throw new KeyNotFoundException("The demanded dates are not available for this hosting unit");
            newDal.addOrder(order);
        }



        ////implementation de supression
        public void deleteHostingUnit(long HostingUnitKey)
        {
            //verifie si le logement est occuppé et si c'est le cas il ne peut pas le supprimer
            var result = from hostingUnit in newDal.GetAllHostingUnitsOccupied()
                         where hostingUnit.HostingUnitKey == HostingUnitKey
                         select hostingUnit;
            if (result.Count() == 0)//si le logement ne se trouve pas dans la liste des logements occupés on le supprime 
                newDal.deleteHostingUnit(HostingUnitKey);
        }
        public void deleteGuestRequest(long guestRequestKey)
        {

        }

        ////implementation de mise a jour
        public void uptadeHostingUnit(HostingUnit updateHostingUnit)
        {
            newDal.uptadeHostingUnit(updateHostingUnit);
        }
        public void updateGuestRequest(GuestRequest updateGuestRequest)
        {
           

        } 
        public void updateOrder(Order updateOrder)
        {
            //seulement si le deal n'a pas été conclu je peux changer le statut de la demande
            if (updateOrder.guestRequest.canChangeStatusOfRequirement)
                newDal.updateOrder(updateOrder);
            if (updateOrder.guestRequest.StatusOfRequest == BE.BE.StatutRequirement.DealClosed)
            {
                updateOrder.guestRequest.canChangeStatusOfRequirement = false;
                calculateTotalPriceWithComission(updateOrder);
            }
            //si le statut de la demande est closed jappelle la fonction deleteGuestRequest
            if (updateOrder.guestRequest.StatusOfRequest == BE.BE.StatutRequirement.Closed)
                deleteGuestRequest(updateOrder.guestRequest.guestRequestKey);
            //si le statut est que le mail a ete envoye j imprime le mail a l ecran
            if (updateOrder.status == BE.BE.Status.MailSent&&updateOrder.hostofHostingUnitReserved.CollectionClearance)
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
            double priceForsAdults,priceForChildrens;
            priceForsAdults = order.guestRequest.Adults * order.hostingUnitReserved.pricePerDayPerAdult;
            priceForChildrens = order.guestRequest.Children * order.hostingUnitReserved.pricePerDayPerChild;
            order.TotalPrice=priceForsAdults+priceForChildrens+10;
            return order;
        }
    }
}
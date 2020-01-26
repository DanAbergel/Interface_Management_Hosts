using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public static class Cloning
    {
        public static Host Clone(this Host original)
        {
            Host target = new Host
            {
                ID = original.ID,
                PrivateName = original.PrivateName,
                FamilyName = original.FamilyName,
                PhoneNumber = original.PhoneNumber,
                MailAddress = original.MailAddress,
                CollectionClearance = original.CollectionClearance,
                numOfHostingUnit = original.numOfHostingUnit,
                Account = Clone(original.Account)

            };

            return target;
        }
        public static HostingUnit Clone(this HostingUnit original)
        {
            HostingUnit target = new HostingUnit
            {
                HostingUnitKey = original.HostingUnitKey,
                capacityAdults = original.capacityAdults,
                capacityChildren = original.capacityChildren,
                area = original.area,
                HostingUnitName = original.HostingUnitName,
                Diary = original.Diary,
                pricePerDayPerAdult = original.pricePerDayPerAdult,
                pricePerDayPerChild = original.pricePerDayPerChild,
                pool = original.pool,
                jacuzzi = original.jacuzzi,
                garden = original.garden,
                childrenAttraction = original.childrenAttraction,
                succesfulDeals = original.succesfulDeals,
                occupied = original.occupied,
                Owner = Clone(original.Owner),type=original.type


            };


            return target;
        }
        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest target = new GuestRequest
            {
                guestRequestKey = original.guestRequestKey,
                StatusOfRequest = original.StatusOfRequest,
                client = Clone(original.client),
                Adults = original.Adults,
                Children = original.Children,
                EntryDate = original.EntryDate,
                ReleaseDate = original.ReleaseDate,
                RegistrationDate = original.RegistrationDate,
                canChangeStatusOfRequirement = original.canChangeStatusOfRequirement,
                area = original.area,
                SubArea = original.SubArea,
                Pool = original.Pool,
                Jacuzzi = original.Jacuzzi,
                Garden = original.Garden,
                ChildrenAttractions = original.ChildrenAttractions
            };


            return target;
        }

        public static Order Clone(this Order original)
        { 
            Order target = new Order()
            {
                guestRequest = Clone(original.guestRequest),
                OrderKey = original.OrderKey,
                hostingUnitReserved = Clone(original.hostingUnitReserved)
            };


            return target;
        }

        public static BankBranch Clone(this BankBranch original)
        {
            BankBranch target = new BankBranch
            {
                BankNumber = original.BankNumber,
                BankName = original.BankName,
                BranchNumber = original.BranchNumber,
                BranchAddress = original.BranchAddress,
                BranchCity = original.BranchCity
            };

            return target;
        }

        public static Client Clone(this Client orignal)
        {
            Client target = new Client
            {
                ID = orignal.ID,
                PrivateName = orignal.PrivateName,
                FamilyName = orignal.FamilyName,
                MailAddress = orignal.MailAddress,
                NumberPhone = orignal.NumberPhone,
               // bank = Clone(orignal.bank)
            };
            return target;
        }


    }
}

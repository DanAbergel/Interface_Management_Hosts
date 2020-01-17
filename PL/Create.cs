using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PL
{
    public class Program
    {
        public static void CreateNewHosting(BE.HostingUnit newHosting)
        {
            Console.Write("ID:");
            newHosting.Owner.ID = Console.ReadLine();

            Console.Write("capacityAdults: ");
            newHosting.capacityAdults = int.Parse(Console.ReadLine());

            Console.Write("capacityChildren: ");
            newHosting.capacityChildren = int.Parse(Console.ReadLine());

            Console.Write("hostingUnitName: ");
            newHosting.HostingUnitName = Console.ReadLine();

            Console.Write("FamilyName:");
            newHosting.Owner.FamilyName = Console.ReadLine();

            Console.Write("PrivateName: ");
            newHosting.Owner.PrivateName = Console.ReadLine();

            Console.Write("MailAddress: ");
            newHosting.Owner.MailAddress = Console.ReadLine();

            Console.Write("PhoneNumber: ");
            newHosting.Owner.PhoneNumber = Console.ReadLine();

            Console.Write("pricePerAdult: ");
            newHosting.pricePerDayPerAdult = int.Parse(Console.ReadLine());

            Console.Write("pricePerChild: ");
            newHosting.pricePerDayPerChild = int.Parse(Console.ReadLine());

            Console.WriteLine("Do you have a pool? yes, press 1 / no, press 0 ");
            newHosting.pool = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you have a jacuzzi?  yes, press 1 / no, press 0 ");
            newHosting.jacuzzi = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you have a garden?  yes, press 1 / no, press 0 ");
            newHosting.garden = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you have children attractions?  yes, press 1 / no, press 0 ");
            newHosting.childrenAttraction = bool.Parse(Console.ReadLine());

            Console.Write("Did you signed Collection Clearance?:  yes, press 1 / no, press 0");
            newHosting.Owner.CollectionClearance = bool.Parse(Console.ReadLine());
        }

        public static void UpdateHosting(ref BE.HostingUnit myHosting)
        {
            Console.Write("capacityAdults: ");
            myHosting.capacityAdults = int.Parse(Console.ReadLine());

            Console.Write("capacityChildren: ");
            myHosting.capacityChildren = int.Parse(Console.ReadLine());

            Console.Write("hostingUnitName: ");
            myHosting.HostingUnitName = Console.ReadLine();

            Console.Write("FamilyName:");
            myHosting.Owner.FamilyName = Console.ReadLine();

            Console.Write("PrivateName: ");
            myHosting.Owner.PrivateName = Console.ReadLine();

            Console.Write("MailAddress: ");
            myHosting.Owner.MailAddress = Console.ReadLine();

            Console.Write("PhoneNumber: ");
            myHosting.Owner.PhoneNumber = Console.ReadLine();

            Console.Write("pricePerAdult: ");
            myHosting.pricePerDayPerAdult = int.Parse(Console.ReadLine());

            Console.Write("pricePerChild: ");
            myHosting.pricePerDayPerChild = int.Parse(Console.ReadLine());

            Console.WriteLine("Do you have a pool? yes, press 1 / no, press 0 ");
            myHosting.pool = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you have a jacuzzi?  yes, press 1 / no, press 0 ");
            myHosting.jacuzzi = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you have a garden?  yes, press 1 / no, press 0 ");
            myHosting.garden = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you have children attractions?  yes, press 1 / no, press 0 ");
            myHosting.childrenAttraction = bool.Parse(Console.ReadLine());

            Console.Write("Did you signed Collection Clearance?:  yes, press 1 / no, press 0");
            myHosting.Owner.CollectionClearance = bool.Parse(Console.ReadLine());
        }

        public static void CreateNewRequest(GuestRequest newGuestRequest)
        {

            Console.Write("Enter your first name: "); newGuestRequest.client.PrivateName = Console.ReadLine();
            Console.Write("Enter your last name: "); newGuestRequest.client.FamilyName = Console.ReadLine();
            Console.Write("Enter your MailAddress: "); newGuestRequest.client.MailAddress = Console.ReadLine();
            Console.Write("Enter your PhoneNumber: "); newGuestRequest.client.NumberPhone = Console.ReadLine();
            Console.Write("Enter your arrival date:  "); newGuestRequest.EntryDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter your departure date:  "); newGuestRequest.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the num of adults: "); newGuestRequest.Adults = int.Parse(Console.ReadLine());
            Console.Write("Enter the num of children: "); newGuestRequest.Children = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your area choice " + "North - press 0 , South - press 1, " + "Center - press 2, Jerusalem - press 3");
            newGuestRequest.area = (BE.BE.Area)(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter your type " + "Zimmer - press 0, " + "Hotel - press 1, " + "Camping - press 2");
            newGuestRequest.type = (BE.BE.theType)(int.Parse(Console.ReadLine()));


        }

        public static void UpdateRequest(ref GuestRequest myGuestRequest)
        {
            Console.Write("Enter your first name: "); myGuestRequest.client.PrivateName = Console.ReadLine();
            Console.Write("Enter your last name: "); myGuestRequest.client.FamilyName = Console.ReadLine();
            Console.Write("Enter your MailAddress: "); myGuestRequest.client.MailAddress = Console.ReadLine();
            Console.Write("Enter your PhoneNumber: "); myGuestRequest.client.NumberPhone = Console.ReadLine();
            Console.Write("Enter your arrival date:  "); myGuestRequest.EntryDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter your departure date:  "); myGuestRequest.ReleaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the num of adults: "); myGuestRequest.Adults = int.Parse(Console.ReadLine());
            Console.Write("Enter the num of children: "); myGuestRequest.Children = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your area choice " + "North - press 0 , South - press 1, " + "Center - press 2, Jerusalem - press 3");
            myGuestRequest.area = (BE.BE.Area)(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter your type " + "Zimmer - press 0, " + "Hotel - press 1, " + "Camping - press 2");
            myGuestRequest.type = (BE.BE.theType)(int.Parse(Console.ReadLine()));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
namespace PL
{
    class PL
    {
        static void Main(string[] args)
        {
            string str;
            int INT;
            IBL newBL = BLFactory.GetBL();
            Console.WriteLine(@"Hello!!!
Please enter a number for choose option:
1) for add a Hosting Unit in our register
2) for delete your own Hosting Unit from our register
3) for registrate a guest request
4) for delete your own guest request
5) for make an order for one of our Hosting Unit ");

            do
            {
                str = Console.ReadLine();
                INT = int.Parse(str);
                if (INT == 1)
                {
                    HostingUnit hostingUnit = new HostingUnit();
                    Console.Write("capacityAdults: ");
                    str = Console.ReadLine();
                    INT = int.Parse(str);
                    hostingUnit.capacityAdults = INT;
                    Console.Write("capacityChildren: ");
                    str = Console.ReadLine();
                    INT = int.Parse(str);
                    hostingUnit.capacityChildren = INT;
                    Console.Write("hostingUnitName: ");
                    hostingUnit.HostingUnitName = Console.ReadLine();
                    Console.Write("FamilyName:");
                    hostingUnit.Owner.FamilyName = Console.ReadLine();
                    Console.Write("PrivateName: ");
                    hostingUnit.Owner.PrivateName = Console.ReadLine();
                    Console.Write("MailAddress: ");
                    hostingUnit.Owner.MailAddress = Console.ReadLine();
                    Console.Write("PhoneNumber: ");
                    hostingUnit.Owner.PhoneNumber = Console.ReadLine();
                    Console.Write("pricePerAdult: ");
                    str = Console.ReadLine();
                    INT = int.Parse(str);
                    hostingUnit.pricePerDayPerAdult = INT;
                    Console.Write("pricePerChild: ");
                    str = Console.ReadLine();
                    INT = int.Parse(str);
                    hostingUnit.pricePerDayPerChild = INT;
                    Console.WriteLine("Do you have a pool? ");
                    str = Console.ReadLine();
                    hostingUnit.pool = (str.ToLower() == "yes") ? true : false;
                    Console.WriteLine("Do you have a jacuzzi? ");
                    str = Console.ReadLine();
                    hostingUnit.jacuzzi = (str.ToLower() == "yes") ? true : false;
                    Console.WriteLine("Do you have a garden? ");
                    str = Console.ReadLine();
                    hostingUnit.garden = (str.ToLower() == "yes") ? true : false;
                    Console.WriteLine("Do you have children attractions? ");
                    str = Console.ReadLine();
                    hostingUnit.childrenAttraction = (str.ToLower() == "yes") ? true : false;
                    Console.Write("Did you signed Collection Clearance?: ");
                    str = Console.ReadLine();
                    hostingUnit.Owner.CollectionClearance = (str.ToLower() == "yes") ? true : false;
                    newBL.addHostingUnit(hostingUnit);
                    int index = 1;
                    foreach (var item in newBL.getAllHostingUnits())
                    {
                        Console.WriteLine("\n{0}) {1}", index, item);
                        index++;
                    }
                }
            } while (INT != 0);
            Console.ReadKey();
        }
    }
}

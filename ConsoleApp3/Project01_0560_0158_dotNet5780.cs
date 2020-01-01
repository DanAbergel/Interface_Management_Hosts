using BL;
using BE;
using System;

namespace Project01_0560_0158_dotNet5780
{
    class Project01_0560_0158_dotNet5780
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
            str = Console.ReadLine();
            INT = int.Parse(str);
            if (INT == 1)
            {
                HostingUnit  hostingUnit = new HostingUnit();
                Console.Write("capacityAdults: ");
                str = Console.ReadLine();
                INT = int.Parse(str);
                hostingUnit.capacityAdults = INT;
                Console.WriteLine();
                Console.Write("capacityChildren: ");
                 str= Console.ReadLine();
                INT = int.Parse(str);
                hostingUnit.capacityChildren = INT;
                Console.WriteLine();
                Console.Write("hostingUnitName: ");
                hostingUnit.HostingUnitName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("FamilyName:");
                hostingUnit.Owner.FamilyName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("PrivateName: ");
                hostingUnit.Owner.PrivateName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("MailAddress: ");
                hostingUnit.Owner.MailAddress = Console.ReadLine();
                Console.WriteLine();
                Console.Write("PhoneNumber: ");
                hostingUnit.Owner.PhoneNumber = Console.ReadLine();
                Console.WriteLine();
                Console.Write("pricePerAdult: ");
                str= Console.ReadLine();
                INT = int.Parse(str);
                hostingUnit.pricePerDayPerAdult = INT;
                Console.WriteLine();
                Console.Write("pricePerChild: ");
                str= Console.ReadLine();
                INT = int.Parse(str);
                hostingUnit.pricePerDayPerChild = INT;
                Console.WriteLine();
                newBL.addHostingUnit(hostingUnit);
            }
            Console.ReadKey();
        }
    }
    }


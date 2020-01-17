using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;
namespace PL
{
    class PL : Program
    {
        static void Main(string[] args)
        {
            //            string str;
            //          int INT;
            IBL newBL = BLFactory.GetBL();
            //            Console.WriteLine(@"Hello!!!
            //Please enter a number for choose option:
            //1) for add a Hosting Unit in our register
            //2) for delete your own Hosting Unit from our register
            //3) for registrate a guest request
            //4) for delete your own guest request
            //5) for make an order for one of our Hosting Unit ");

            //            do
            //            {
            //                str = Console.ReadLine();
            //                INT = int.Parse(str);
            //                if (INT == 1)
            //                {
            //                    HostingUnit hostingUnit = new HostingUnit();
            //                    Console.Write("capacityAdults: ");
            //                    str = Console.ReadLine();
            //                    INT = int.Parse(str);
            //                    hostingUnit.capacityAdults = INT;
            //                    Console.Write("capacityChildren: ");
            //                    str = Console.ReadLine();
            //                    INT = int.Parse(str);
            //                    hostingUnit.capacityChildren = INT;
            //                    Console.Write("hostingUnitName: ");
            //                    hostingUnit.HostingUnitName = Console.ReadLine();
            //                    Console.Write("FamilyName:");
            //                    hostingUnit.Owner.FamilyName = Console.ReadLine();
            //                    Console.Write("PrivateName: ");
            //                    hostingUnit.Owner.PrivateName = Console.ReadLine();
            //                    Console.Write("MailAddress: ");
            //                    hostingUnit.Owner.MailAddress = Console.ReadLine();
            //                    Console.Write("PhoneNumber: ");
            //                    hostingUnit.Owner.PhoneNumber = Console.ReadLine();
            //                    Console.Write("pricePerAdult: ");
            //                    str = Console.ReadLine();
            //                    INT = int.Parse(str);
            //                    hostingUnit.pricePerDayPerAdult = INT;
            //                    Console.Write("pricePerChild: ");
            //                    str = Console.ReadLine();
            //                    INT = int.Parse(str);
            //                    hostingUnit.pricePerDayPerChild = INT;
            //                    Console.WriteLine("Do you have a pool? ");
            //                    str = Console.ReadLine();
            //                    hostingUnit.pool = (str.ToLower() == "yes") ? true : false;
            //                    Console.WriteLine("Do you have a jacuzzi? ");
            //                    str = Console.ReadLine();
            //                    hostingUnit.jacuzzi = (str.ToLower() == "yes") ? true : false;
            //                    Console.WriteLine("Do you have a garden? ");
            //                    str = Console.ReadLine();
            //                    hostingUnit.garden = (str.ToLower() == "yes") ? true : false;
            //                    Console.WriteLine("Do you have children attractions? ");
            //                    str = Console.ReadLine();
            //                    hostingUnit.childrenAttraction = (str.ToLower() == "yes") ? true : false;
            //                    Console.Write("Did you signed Collection Clearance?: ");
            //                    str = Console.ReadLine();
            //                    hostingUnit.Owner.CollectionClearance = (str.ToLower() == "yes") ? true : false;
            //                    newBL.addHostingUnit(hostingUnit);
            //                    int index = 1;
            //                    foreach (var item in newBL.getAllHostingUnits())
            //                    {
            //                        Console.WriteLine("\n{0}) {1}", index, item);
            //                        index++;
            //                    }

            //                }
            //                if (INT == 2)
            //                {
            //                    str= Console.ReadLine();
            //                    long INT2 = long.Parse(str);
            //                    newBL.deleteHostingUnit(INT2);
            //                    int index1 = 1;
            //                    foreach (var item in newBL.getAllHostingUnits())
            //                    {
            //                        Console.WriteLine("\n{0}) {1}", index1, item);
            //                        index1++;
            //                    }

            //                }
            //                if(INT==3)
            //                {
            //                    GuestRequest guestRequest=new GuestRequest();

            //                    guestRequest.client.FamilyName = "Abergel";
            //                    guestRequest.client.PrivateName = "Dan";
            //                    guestRequest.client.MailAddress ="kjhbgv";
            //                    guestRequest.client.NumberPhone = "48651";
            //                    guestRequest.EntryDate = DateTime.Parse("1/2/2020");
            //                    guestRequest.ReleaseDate = DateTime.Parse("15/3/2020");
            //                    guestRequest.area = BE.BE.Area.Center;
            //                    guestRequest.type = BE.BE.theType.Zimmer;
            //                    guestRequest.Adults = int.Parse("3");
            //                    guestRequest.Children = int.Parse("2");
            //                    guestRequest.Pool = BE.BE.Criterion.NotInterested;
            //                    guestRequest.Garden = BE.BE.Criterion.Possible;
            //                    guestRequest.Jacuzzi = BE.BE.Criterion.Necessary;
            //                    guestRequest.ChildrenAttractions = BE.BE.Criterion.NotInterested;
            //                    newBL.addGuestRequest(guestRequest);
            //                    guestRequest.client.FamilyName = "Abergel";
            //                    guestRequest.client.PrivateName = "Dan";
            //                    guestRequest.client.MailAddress = "kjhbgv";
            //                    guestRequest.client.NumberPhone = "48651";
            //                    guestRequest.EntryDate = DateTime.Parse("1/2/2020");
            //                    guestRequest.ReleaseDate = DateTime.Parse("15/3/2020");
            //                    guestRequest.area = BE.BE.Area.Center;
            //                    guestRequest.type = BE.BE.theType.Zimmer;
            //                    guestRequest.Adults = int.Parse("3");
            //                    guestRequest.Children = int.Parse("2");
            //                    guestRequest.Pool = BE.BE.Criterion.NotInterested;
            //                    guestRequest.Garden = BE.BE.Criterion.Possible;
            //                    guestRequest.Jacuzzi = BE.BE.Criterion.Necessary;
            //                    guestRequest.ChildrenAttractions = BE.BE.Criterion.NotInterested;
            //                    foreach (var item in newBL.getAllGuestRequest())
            //                        Console.WriteLine(item);
            //                }
            //            } while (INT != 0);
            //            Console.ReadKey();




            BE.GuestRequest myGuestRequest;
            //BE.Host host;
            BE.HostingUnit myHostingUnit;
            // BE.Order order;

            int choose;
            long ID;

            try
            {
                Console.WriteLine("Host press 1\n" + "Client press 2\n" + "Exit press 0");
                choose = int.Parse(Console.ReadLine());
                while (choose != 0)
                {

                    switch (choose)
                    {
                        case 1:
                            {
                                Console.WriteLine("Add new Hosting Unit press 1\n" + "Exist Hosting unit press 2\n" + "Exit press 0");
                                choose = int.Parse(Console.ReadLine());
                                while (choose != 0)
                                {
                                    switch (choose)
                                    {
                                        case 1:
                                            {
                                                BE.HostingUnit newHostingUnit = new HostingUnit();
                                                CreateNewHosting(newHostingUnit);
                                                newBL.addHostingUnit(newHostingUnit);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Enter your hosting key ");
                                                ID = int.Parse(Console.ReadLine());
                                                myHostingUnit = newBL.GetHostingUnitByID(ID);
                                                Console.WriteLine(" update it press 1\n" + "delete it press 2\n" + "Exit press 0");
                                                choose = int.Parse(Console.ReadLine());
                                                while (choose != 0)
                                                {
                                                    switch (choose)
                                                    {
                                                        case 1:
                                                            {
                                                                UpdateHosting(ref myHostingUnit);
                                                                newBL.uptadeHostingUnit(myHostingUnit);
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                newBL.deleteHostingUnit(ID);
                                                                break;
                                                            }
                                                    }
                                                    Console.WriteLine(" Exit press 0");
                                                    choose = int.Parse(Console.ReadLine());
                                                }
                                                break;
                                            }
                                    }
                                    Console.WriteLine("Add new Hosting Unit press 1\n" + "Exist Hosting unit press 2\n" + "Exit press 0");
                                    choose = int.Parse(Console.ReadLine());
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Add new request press 1\n" + "Exist request press 2\n" + "Exit press 0");
                                choose = int.Parse(Console.ReadLine());
                                while (choose != 0)
                                {
                                    switch (choose)
                                    {
                                        case 1:
                                            {
                                                BE.GuestRequest newGuestRequest = new GuestRequest();
                                                CreateNewRequest(newGuestRequest);
                                                newBL.addGuestRequest(newGuestRequest);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Enter your guestRequestKey");
                                                ID = int.Parse(Console.ReadLine());
                                                myGuestRequest = newBL.GetGuestRequestByID(ID);
                                                Console.WriteLine(" delete request press 1\n" + "Update your request press 2\n");
                                                choose = int.Parse(Console.ReadLine());
                                                while (choose != 0)
                                                {
                                                    switch (choose)
                                                    {
                                                        case 1:
                                                            {
                                                                newBL.deleteGuestRequest(ID);
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                UpdateRequest(ref myGuestRequest);
                                                                newBL.updateGuestRequest(myGuestRequest);
                                                                break;
                                                            }

                                                    }
                                                    Console.WriteLine(" Exit press 0");
                                                    choose = int.Parse(Console.ReadLine());

                                                }
                                                break;
                                            }

                                    }
                                    Console.WriteLine("Add new request press 1\n" + "Exist request press 2\n" + "Exit press 0");
                                    choose = int.Parse(Console.ReadLine());

                                }
                                break;
                            }

                    }
                    Console.WriteLine("host press 1\n" + "client press 2\n" + "Exit press 0");
                    choose = int.Parse(Console.ReadLine());
                }

            }
            catch (DuplicateWaitObjectException g)
            {
                Console.WriteLine(g);
            }
            catch (ArgumentException g)
            {
                Console.WriteLine(g);
            }
            catch (KeyNotFoundException g)
            {
                Console.WriteLine(g);
            }
            catch (MissingMemberException g)
            {
                Console.WriteLine(g);
            }
        }
    }
}




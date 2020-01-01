using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01_0560_0158_dotNet5780
{
    class Project01_0560_0158_dotNet5780
    {
        static void Main(string[] args)
        {
            IBL newBL = BLFactory.GetBL();
            Console.WriteLine(@"Hello!!!
Please enter a number for choose option:
1) for add a Hosting Unit in our register
2) for delete your own Hosting Unit from our register
3) for registrate a guest request
4) for delete your own guest request
5) for make an order for one of our Hosting Unit ");
            Console.ReadKey();
        }
    }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        public int BankNumber;
        public string BankName;
        public int BranchNumber;
        public string BranchAddress;
        public string BranchCity;


        public override string ToString()
        {
            string str = "";
            str += "Bank Name: " + BankName;
            str += " Bank Number: " + BankNumber;
            str += "\nBranch Number:" + BranchNumber;
            str += "Address :" + BranchAddress + " at " + BranchCity+"\n";
            return str;
        }
    }
}

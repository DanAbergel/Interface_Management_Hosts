using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        private int BankNumber;
        private string BankName;
        private int BranchNumber;
        private string BranchAddress;
        private string BranchCity;


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

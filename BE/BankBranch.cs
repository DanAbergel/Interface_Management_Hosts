using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }

        public BankBranch()
        {

        }
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

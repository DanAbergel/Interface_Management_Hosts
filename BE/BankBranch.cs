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

        //ctor
        public BankBranch(int BankNumber, string BankName, int BranchNumber, string BranchAddress, string BranchCity)
        {
            this.BankNumber = BankNumber;
            this.BankName = BankName;
            this.BranchNumber = BranchNumber;
            this.BranchAddress = BranchAddress;
            this.BranchCity = BranchCity;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

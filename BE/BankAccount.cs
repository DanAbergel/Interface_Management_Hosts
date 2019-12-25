using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {
        private int BankNumber;
        private string BankName;
        private int BranchNumber;
        private string BranchAddress;
        private string BranchCity;
        private int BankAccountNumber;

        //ctor
        public BankAccount(int BankNumber, string BankName, int BranchNumber, string BranchAddress, string BranchCity, int BankAccountNumber)
        {
            this.BankNumber = BankNumber;
            this.BankName = BankName;
            this.BranchNumber = BranchNumber;
            this.BranchAddress = BranchAddress;
            this.BranchCity = BranchCity;
            this.BankAccountNumber = BankAccountNumber;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}

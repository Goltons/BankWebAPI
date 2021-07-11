using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.LoanService
{
    public class LoanService : ILoanService
    {

        public Loan GetLoanById(int LoanId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetPaymentPlan(int LoanTerm, double amount, string LoanType, double interestRate)
        {
            throw new NotImplementedException();
        }

        public void PayLaonDebt(int loanId, double amountToPay)
        {
            throw new NotImplementedException();
        }

        public Loan TakeLoan(long customerTcNo, int LoanTerm, double LoanAmount, string LoanType)
        {
            throw new NotImplementedException();
        }

        public void TakeLoan(long tcNo, double amount, int LoanTerm, string LoanType)
        {
            throw new NotImplementedException();
        }
    }
}

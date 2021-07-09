using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.LoanRepository
{
    public class LoanRepository : ILoanRepository
    {
        public List<string> GetPaymentPlan(int LoanTerm, double amount, string LoanType, double interestRate)
        {
            throw new NotImplementedException();
        }

        public void PayLaonDebt(int loanId, double amountToPay)
        {
            throw new NotImplementedException();
        }

        public void TakeLoan(long tcNo, double amount)
        {
            throw new NotImplementedException();
        }
    }
}

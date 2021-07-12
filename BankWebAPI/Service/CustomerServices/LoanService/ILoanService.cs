
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.LoanService
{
    public interface ILoanService
    {
        void TakeLoan(long tcNo, double amount, int LoanTerm, string LoanType);
        void PayLaonDebt(int loanId, double amountToPay);
        List<string> GetPaymentPlan(int LoanTerm, double amount, string LoanType, double interestRate);
    }
}

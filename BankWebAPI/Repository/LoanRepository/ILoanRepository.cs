using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.LoanRepository
{
    interface ILoanRepository
    {
        void TakeLoan(long tcNo,double amount);
        void PayLaonDebt(int loanId, double amountToPay);
        List<string> GetPaymentPlan(int LoanTerm,double amount,string LoanType,double interestRate);

    }
}

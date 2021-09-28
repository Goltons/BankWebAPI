
using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.LoanService
{
    public interface ILoanService
    {
        void LoanApply(Loan loan);
        void PayLaonDebt(int loanId, double amountToPay);
        List<string> GetPaymentPlan(int LoanTerm, double amount, double interestRate);
        Loan ConfirmLoan(Loan loanToApprove);
    }
}

using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.BankWorkerServices.BankEmployee
{
    public interface IBankEmployeeService
    {
        void LoanApprove(Loan loan);
        void AccountApprove(Account account);
        void CardApprove(Card card);
        void TransferApprove(Transfer transfer);
    }
}

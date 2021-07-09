using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerService.LoanService
{
    interface ILoanService
    {
        Loan TakeLoan(long customerTcNo,int LoanTerm,double LoanAmount,string LoanType);
        Loan GetLoanById(int LoanId);
    }
}

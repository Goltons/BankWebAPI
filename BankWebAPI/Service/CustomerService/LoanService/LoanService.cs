using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerService.LoanService
{
    public class LoanService : ILoanService
    {
        
        public Loan GetLoanById(int LoanId)
        {
            throw new NotImplementedException();
        }

        public Loan TakeLoan(long customerTcNo, int LoanTerm, double LoanAmount, string LoanType)
        {
            throw new NotImplementedException();
        }
    }
}

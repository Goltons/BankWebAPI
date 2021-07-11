using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.LoanRepository
{
    interface ILoanRepository
    {
        List<Loan> GetAllByTcNo(long tcNo);
        Loan GetByTcNo(long tcNo);

    }
}

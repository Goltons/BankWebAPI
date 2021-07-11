using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository1.CustomerRepository.LoanRepository
{
    interface ILoanRepository
    {
        List<Loan> GetAllByTcNo(long tcNo);
        Loan GetByTcNo(long tcNo);

    }
}

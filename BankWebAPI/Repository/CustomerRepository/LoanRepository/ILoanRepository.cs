using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.LoanRepository
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {
        List<Loan> GetAllByTcNo(string tcNo);
        Loan GetByTcNo(string tcNo);

    }
}

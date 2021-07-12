
using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.AccountRepository
{
    public interface IAccountRepository: IBaseRepository<Account>
    {

        Account getByAccountNumber(int AccountNumber);
    }
}

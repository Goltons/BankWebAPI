using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.AccountRepository
{
    interface IAccountRepository
    {
        void CreateNewAccount(Account account);
    }
}

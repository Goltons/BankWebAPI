using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.AccountService
{
    public interface IAccountService
    {
        void AddAccount(Account account);
        Account GetAccountByAccountNumber(int AccountNumber);
    }
}

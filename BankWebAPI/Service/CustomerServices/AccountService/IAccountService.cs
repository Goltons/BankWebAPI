using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerService.AccountService
{
    interface IAccountService
    {
        void AddAccount(Account account);
        void GetAccountByAccountNumber(int AccountNumber);
    }
}

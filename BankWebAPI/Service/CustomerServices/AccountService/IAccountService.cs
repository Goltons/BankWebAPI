﻿using BankWebAPI.Model.Customer;

namespace BankWebAPI.Service.CustomerServices.AccountService
{
    public interface IAccountService
    {
        void AddAccount(Account account);
        int AccountNumberGenerator();
        Account[] Accounts(string tcno);
        bool CheckAccount(int customerId);
        Account getMainAccount(int AccountNumber);
        Account getByCustomerId(int customerId);
    }
}

﻿using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices.AccountService
{
    interface IAccountService
    {
        void AddAccount(Account account);
        void GetAccountByAccountNumber(int AccountNumber);
    }
}
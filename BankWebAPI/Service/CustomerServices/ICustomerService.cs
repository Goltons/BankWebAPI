﻿using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices
{
    public interface ICustomerService
    {
        //jwt eklenecek
        void Login(string TcNo, string password);
        void Register(Customer customer);

        Customer GetByTcNo(string tcNo);
    }
}

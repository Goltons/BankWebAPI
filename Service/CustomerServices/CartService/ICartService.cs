﻿using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices.CartService
{
    interface ICartService
    {
        void AddNewCartToAcc(Cart cart);
        void DeleteCartFromAccount(int id);
        void CloseCartLimit(int id);
        void IncreaseCartLimit(int id, double amount);
        void DecreaseCartLimit(int id, double amaunt);
        void PayCartDebt(int id, double amountToPay);
        void UseCartLimit(int id, double amountToUse);
    }
}
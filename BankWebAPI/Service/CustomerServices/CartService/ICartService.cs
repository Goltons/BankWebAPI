using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.CartService
{
    public interface ICartService
    {
        void AddNewCartToAcc(Cart cart);
        void DeleteCartFromAccount(int id);
        void CloseCartLimit(int id);
        void IncreaseCartLimit(int id, double amount);
        void DecreaseCartLimit(int id, double amaunt);
        void PayCartDebt(int id, double amountToPay);
        void AddFirstCart(int accountId);
        //  string IBANGenerate();

    }
}

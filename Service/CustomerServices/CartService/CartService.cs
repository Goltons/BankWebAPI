using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices.CartService
{
    public class CartService : ICartService
    {
        public void AddNewCartToAcc(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void CloseCartLimit(int id)
        {
            throw new NotImplementedException();
        }

        public void DecreaseCartLimit(int id, double amaunt)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartFromAccount(int id)
        {
            throw new NotImplementedException();
        }

        public void IncreaseCartLimit(int id, double amount)
        {
            throw new NotImplementedException();
        }

        public void PayCartDebt(int id, double amountToPay)
        {
            throw new NotImplementedException();
        }

        public void UseCartLimit(int id, double amountToUse)
        {
            throw new NotImplementedException();
        }
    }
}

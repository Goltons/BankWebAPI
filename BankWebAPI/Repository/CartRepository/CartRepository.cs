using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //kontrol kodlarının yazılması ve ardından veritabanına kaydedilmesi
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

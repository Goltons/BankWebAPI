using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.CartRepository
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

        }

        public void CloseCartLimit(int id)
        {
            throw new NotImplementedException();
        }

        public void DecreaseCartLimit(int id, double amaunt)
        {
            throw new NotImplementedException();
        }

        public void delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteCartFromAccount(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> getAll()
        {
            throw new NotImplementedException();
        }

        public Cart GetById(int id)
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

        public void save(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void update(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void UseCartLimit(int id, double amountToUse)
        {
            throw new NotImplementedException();
        }
    }
}

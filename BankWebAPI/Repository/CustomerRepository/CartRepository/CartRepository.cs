using BankWebAPI.Model;
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


        public void delete(Cart entity)
        {
           
            _context.Carts.Remove(entity);
            _context.SaveChanges();
        }
        public List<Cart> getAll()
        {
            throw new NotImplementedException();
        }

        public Cart GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void save(Cart entity)
        {
            _context.Carts.Add(entity);
            _context.SaveChanges();
        }

        public void update(Cart entity)
        {
            _context.Carts.Update(entity);
            _context.SaveChanges();
        }
    }
}

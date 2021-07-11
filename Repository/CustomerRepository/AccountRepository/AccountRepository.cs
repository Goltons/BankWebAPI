using Models.Customer;
using Models.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository1.CustomerRepository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Account GetById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.AccountId == id);
        }

        public void save(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void delete(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }

        public void update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }

        public List<Account> getAll()
        {
            return _context.Accounts.ToList();
        }
    }
}

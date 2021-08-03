using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace BankWebAPI.Repository.CustomerRepository.AccountRepository
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

        public Account getByAccountNumber(int AccountNumber)
        {
            return _context.Accounts.FirstOrDefault(
                p => p.AccountNumber == AccountNumber);
        }

        public Account[] getAllAccountsByTcNo(string tcno)
        {
            Customer customer = _context.Customers.FirstOrDefault(p => p.TcNo == tcno);
            return _context.Accounts.Where(p => p.CustomerId == customer.CustomerId).ToArray();
        }

        public bool checkAccount(int customerId)
        {
            if (_context.Accounts.FirstOrDefault(p => p.CustomerId == customerId) != null) return true;
            return false;
        }

        public int AccountSupplementNumber(int accNum)
        {
            List<Account> accounts = getAllByAccountNumber(accNum);
            Account account = accounts.Last();
            return account.AccountSupplementNumber;
        }

        public Account getByCustomerId(int customerId)
        {
            return _context.Accounts.FirstOrDefault(p => p.CustomerId == customerId);
        }

        public List<Account> getAllByAccountNumber(int accNumber)
        {
            return _context.Accounts.Where(p => p.AccountNumber == accNumber).ToList();
        }

        public Account getAccountForTransfer(int branchCode, int accountNumber, int SupplementNumber, string receiverName)
        {
            return _context.Accounts.FirstOrDefault(p => p.AccountBranchCode == branchCode && p.AccountNumber == accountNumber && p.AccountSupplementNumber == SupplementNumber&&p.Customer.CustomerName==receiverName);

        }

        public Account getAccountForIBANTransfer(string iban, string receiverName)
        {
            return _context.Accounts.FirstOrDefault(p => p.IBAN == iban && p.Customer.CustomerName == receiverName);
        }
    }
}

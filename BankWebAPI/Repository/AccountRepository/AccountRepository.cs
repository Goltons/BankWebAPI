using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateNewAccount(Account account)
        {
            string accno = GenerateAccountNumber();
            account.AccountNumber = Int32.Parse(accno);
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public static string GenerateAccountNumber()
        {
            string accno = "";
            for (int i = 0; i < 8; i++)
            {
                Random rnd = new Random();
                int random = rnd.Next(10);
                if (i == 0 && random == 0) { accno += rnd.Next(1, 10); }
                accno += random;
            }
            return accno;
        }
    }
}

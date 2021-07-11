using Models.Customer;
using Models.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void GetAccountByAccountNumber(int AccountNumber)
        {
            throw new NotImplementedException();
        }
    }
}

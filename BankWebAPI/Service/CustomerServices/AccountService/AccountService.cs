using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public int AccountNumberGenerator()
        {
            string a = "";
            Random rnd=new Random();
            for (int i = 0; i < 8; i++)
            {
                
                int b = rnd.Next(0, 10);
                if (i == 0 && b == 0) a += rnd.Next(1, 10).ToString();
                a+=rnd.Next(0,10).ToString();
            }
             return Int32.Parse(a);

        }

        public void AddAccount(Account account)
        {
                      
            _accountRepository.save(account);
        }
        public Account GetAccountByAccountNumber(int AccountNumber)
        {
            return _accountRepository.getByAccountNumber(AccountNumber);   
        }
    }
}

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

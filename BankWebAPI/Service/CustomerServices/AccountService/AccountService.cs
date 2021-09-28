using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using BankWebAPI.Service.CustomerServices.CartService;
using System;

namespace BankWebAPI.Service.CustomerServices.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }
        
        public Account[] Accounts(string tcno)
        {
            return _accountRepository.getAllAccountsByTcNo(tcno);
        }
        public bool CheckAccount(int customerId)
        {
            return _accountRepository.checkAccount(customerId);
        }
        public Account getByCustomerId(int customerId)
        {
            return _accountRepository.getByCustomerId(customerId);
        }
        public Account getMainAccount(int AccountNumber)
        {
            return _accountRepository.getByAccountNumber(AccountNumber);
        }
        public int AccountNumberGenerator()
        {
            string a = "";
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                int b = rnd.Next(0, 10);
                if (i == 0 && b == 0) a += rnd.Next(1, 10).ToString();
                a += b.ToString();
            }
            return Int32.Parse(a);
        }
        public void AddAccount(Account account)
        {
            account.CreatedDate = DateTime.Now;
            account.Customer = _customerRepository.GetById(account.CustomerId);
            //daha önce hesap oluşturmuş ve yeni bir hesap daha oluşturulacağı zaman bu method çalışacak
            if (CheckAccount(account.CustomerId))
            {
                Account mainAccount = _accountRepository.getByCustomerId(account.CustomerId);
                account.AccountNumber = mainAccount.AccountNumber;
                account.AccountAdditionalNumber = _accountRepository.AccountSupplementNumber(account.AccountNumber)+1;
                Random rnd = new Random();
                account.IBAN = "TR" + rnd.Next(10, 50).ToString()
                    + "000001" + account.AccountNumber+ account.AccountAdditionalNumber.ToString();
                //ek no'ya 1 eklenecek account code düzenlemesinin yapılması
                _accountRepository.save(account);
            }
            else
            {
                int accnum = AccountNumberGenerator();
                if (_accountRepository.getByAccountNumber(accnum) != null) accnum = AccountNumberGenerator();
                //default hesap ek no 5000 
                account.AccountAdditionalNumber = 5000;
                account.AccountNumber = accnum;
                Random rnd = new Random();
                account.IBAN = "TR" + rnd.Next(10, 50).ToString() + "000001" 
                    + accnum + account.AccountAdditionalNumber.ToString();
                _accountRepository.save(account);
            }

        }
    }
}

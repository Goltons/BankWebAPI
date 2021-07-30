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
        public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository = null)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
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

        public Account[] Accounts(string tcno)
        {
            return _accountRepository.getAllAccountsByTcNo(tcno);
        }


        public void AddAccount(Account account)
        {
            //daha önce hesap oluşturmuş ve yeni bir hesap daha oluşturulacağı zaman bu method çalışacak
            if (CheckAccount(account.CustomerId))
            {
                Account mainAccount = _accountRepository.getByCustomerId(account.CustomerId);
                account.Customer = _customerRepository.GetById(account.CustomerId);
                account.CreatedDate = DateTime.Now;
                account.AccountNumber = mainAccount.AccountNumber;
                account.AccountSupplementNumber = _accountRepository.AccountSupplementNumber(account.AccountNumber) + 1;
                account.IBAN = "TR45000001" + account.AccountNumber + account.AccountSupplementNumber.ToString();
                //supplement number son getirilip 1 arttırılacak account code düzenlemesinin yapılması
                _accountRepository.save(account);
            }
            else
            {
                //gönderilen hesap ilk kayıt hesabımı bunun kontrolünün yapılıp yönledirilmesi
                //eğer ilk kez ise else içindeki addaccount methoduna yönlendirme yapılacak
                int accnum = AccountNumberGenerator();

                if (_accountRepository.getByAccountNumber(accnum) != null) accnum = AccountNumberGenerator();
                //default hesap ek no su 5000 olarak belirtildiği için ilk hesap açımında onu değer olarak atıyorum.
                account.Customer = _customerRepository.GetById(account.CustomerId);
                account.AccountSupplementNumber = 5000;
                account.AccountNumber = accnum;
                account.CreatedDate = DateTime.Now;
                account.IBAN = "TR45000001" + accnum + account.AccountSupplementNumber.ToString();
                _accountRepository.save(account);
            }

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
    }
}


using BankWebAPI.Model.Customer;
using System.Collections.Generic;

namespace BankWebAPI.Repository.CustomerRepository.AccountRepository
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Account[] getAllAccountsByTcNo(string  tcno);
        Account getByAccountNumber(int AccountNumber);
        bool checkAccount(int customerId);
        Account getByCustomerId(int customerId);
        int AccountSupplementNumber(int accNumber);
        List<Account> getAllByAccountNumber(int accNumber);
        Account getAccountForTransfer(int branchCode, int accountNumber, int SupplementNumber,string receiverName);
        Account getAccountForIBANTransfer(string iban, string receiverName);
        

    }
}

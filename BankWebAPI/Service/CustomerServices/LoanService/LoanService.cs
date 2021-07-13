using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository.LoanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.LoanService
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public Loan GetLoanById(int LoanId)
        {
            return _loanRepository.GetById(LoanId);
        }
        public List<string> GetPaymentPlan(int LoanTerm, double amount, string LoanType, double interestRate)
        {
            //hesaplama yapıp string dizi oluşturup geri dönme
            throw new NotImplementedException();
        }
        public void PayLaonDebt(int loanId, double amountToPay)
        {
            //loanı bulup ilk ödemeyi diziden silmek daha sonra borcu güncelleyi geri dönöek
           
        }
        public void TakeLoan(long tcNo, double amount, int LoanTerm, string LoanType)
        {//loan validate,mhizden onay beklenmesi
            
        }
    }
}

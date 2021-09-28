using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using BankWebAPI.Repository.CustomerRepository.CartRepository;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICardRepository _cardRepository;
        public LoanService(ILoanRepository loanRepository, ICustomerRepository customerRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
        }

        public Loan ConfirmLoan(Loan loanToApprove)
        {
            //kullanıcı ana hesaba aktarım yapılacak
            //onaylanmama durumunda bir işlem yapılmayacak veritabanında 
            if (loanToApprove.Status=="Onaylandı")
            {
                //ana hesap ve karta ekleme ve hesap borcunu güncelleme
                Account loanAccount = _accountRepository.getByCustomerId(loanToApprove.CustomerId);
                Card cardToAddLoanAmount = _cardRepository.GetByAccountId(loanAccount.AccountId);
                loanAccount.Balance += loanToApprove.LoanAmount;
                loanAccount.TotalDebt += loanToApprove.LoanAmount;
                cardToAddLoanAmount.CardBalance += loanToApprove.LoanAmount;
                _cardRepository.update(cardToAddLoanAmount);
                _accountRepository.update(loanAccount);
            }
            return loanToApprove;
        }

        public Loan GetLoanById(int LoanId)
        {
            return _loanRepository.GetById(LoanId);
        }
        public List<string> GetPaymentPlan(int LoanTerm, double amount, double interestRate)
        {
            //kkdf faizin yüzde 15'i kadar,bsmv faizin yüzde 5'i kadar
            double faizTutarı, kkdf,bsmv,anapara,taksit;
            interestRate = interestRate / 100;
            taksit = amount * (1.2*interestRate*Math.Pow((1+1.2*interestRate),LoanTerm))
                /(Math.Pow((1+1.2*interestRate),LoanTerm)-1);
            List<string> PaymentPlan = new List<string>(LoanTerm);
            for (int i = 0; i < LoanTerm; i++)
            {
                faizTutarı = amount * interestRate;
                kkdf = faizTutarı * 0.15;
                bsmv = faizTutarı * 0.05;
                anapara = taksit - faizTutarı - kkdf - bsmv;
                amount -=anapara;              
                 PaymentPlan.Add( String.Format(
                    "{0} || {1} || {2} || {3} || {4} || {5} || {6}"
                    ,i+1,taksit,anapara,faizTutarı,kkdf,bsmv,amount));
                //ödenecek ay,ödenecek toplam taksit,anapara tutarı,faiz tutarı,
                //kkdf tutarı,bsmv tutarı,kalan toplam ödeme
            }
            return PaymentPlan;
        }
        public void LoanApply(Loan loan)
        {
            Customer customer = _customerRepository.GetById(loan.CustomerId);
            loan.Customer = customer;
            loan.CustomerId = customer.CustomerId;
            loan.CreatedDate = DateTime.Now;
            _loanRepository.save(loan);
        }
        public void PayLaonDebt(int loanId, double amountToPay)
        {
            //loanı bulup ilk ödemeyi diziden silmek daha sonra borcu güncelleyi geri dönöcek
            Loan LoanToPay = _loanRepository.GetById(loanId);
            //sql tablosunda değişiklikler yapıldıktan sonra yazılacaktır 
            //react tasarım ile devam edecek kod yazımı
        }
      
    }
}

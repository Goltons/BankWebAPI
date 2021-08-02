using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
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
        public LoanService(ILoanRepository loanRepository, ICustomerRepository customerRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
        }
        public Loan GetLoanById(int LoanId)
        {
            return _loanRepository.GetById(LoanId);
        }
        public string[] GetPaymentPlan(int LoanTerm, double amount, double interestRate)
        {
            //hesaplama yapıp ödeme planı dizisi oluşturup geri dönme
            //kkdf faizin yüzde 15 i kadar
            //bsmv faizin yüzde 5 i kadar
            
            double faizTutarı, kkdf,bsmv,anapara,taksit;
            taksit = amount * (1.2*interestRate*Math.Pow((1+1.2*interestRate),LoanTerm))
                /(Math.Pow((1+1.2*interestRate),LoanTerm)-1);

            string[] PaymentPlan = new string[LoanTerm];

            for (int i = 0; i < LoanTerm; i++)
            {
                faizTutarı = amount * interestRate;
                kkdf = faizTutarı * 0.15;
                bsmv = faizTutarı * 0.05;
                anapara = taksit - faizTutarı - kkdf - bsmv;
                amount -=anapara;
                
                PaymentPlan[i] = String.Format(
                    "{0} || {1} || {2} || {3} || {4} || {5} || {6}"
                    ,i+1,taksit,anapara,faizTutarı,kkdf,bsmv,amount);
                //ödenecek ay,ödenecek toplam taksit,anapara tutarı,faiz tutarı,kkdf tutarı,bsmv tutarı,kalan toplam ödeme
            }
            return PaymentPlan;
        }
        public void PayLaonDebt(int loanId, double amountToPay)
        {
            //loanı bulup ilk ödemeyi diziden silmek daha sonra borcu güncelleyi geri dönöcek
            Loan LoanToPay = _loanRepository.GetById(loanId);
            //sql tablosunda değişiklikler yapıldıktan sonra yazılacaktır 
            //react tasarım ile devam edecek kod yazımı
        }
        public void LoanApply(Loan loan)
        {
            Customer customer = _customerRepository.GetById(loan.CustomerId);
            loan.Customer = customer;
            loan.CustomerId = customer.CustomerId;
            loan.CreatedDate = DateTime.Now;
            _loanRepository.save(loan);
        }
    }
}

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
        public string[] GetPaymentPlan(int LoanTerm, double amount, string LoanType, double interestRate)
        {
            //hesaplama yapıp ödeme planı dizisi oluşturup geri dönme
            //kkdf faizin yüzde 15 i kadar
            //bsmv faizin yüzde 5 i kadar
            
            double faizTutarı=0;
            double kkdf=0;
            double bsmv=0;
            double anapara = 0;
            double taksit = 0;
            taksit = amount * (1.2*interestRate*Math.Pow((1+1.2*interestRate),LoanTerm))
                /(Math.Pow((1+1.2*interestRate),LoanTerm)-1);
          
            
            string[] PaymentPlan = new string[LoanTerm];

            for (int i = 0; i < LoanTerm; i++)
            {
                faizTutarı = amount * interestRate;
                kkdf = faizTutarı * 0.15;
                bsmv = faizTutarı * 0.05;
                anapara = taksit - faizTutarı - kkdf - bsmv;
                amount = amount- anapara;
                
                PaymentPlan[i] = String.Format(
                    "{0},{1},{2},{3},{4},{5},{6}"
                    ,i+1,taksit,anapara,faizTutarı,kkdf,bsmv,amount);
                //ödenecek ay,ödenecek toplam taksit,anapara tutarı,faiz tutarı,kkdf tutarı,bsmv tutarı,kalan toplam ödeme
            }

            return PaymentPlan;
        }
        public void PayLaonDebt(int loanId, double amountToPay)
        {
            //loanı bulup ilk ödemeyi diziden silmek daha sonra borcu güncelleyi geri dönöek
            Loan LoanToPay = _loanRepository.GetById(loanId);
            //sql tablosunda değişiklikler yapıldıktan sonra yazılacaktır 
            //react tasarım ile devam edecek kod yazımı

           
        }
        public void TakeLoan(long tcNo, double amount, int LoanTerm, string LoanType)
        {//loan validate,mhizden onay beklenmesi
            
        }
    }
}

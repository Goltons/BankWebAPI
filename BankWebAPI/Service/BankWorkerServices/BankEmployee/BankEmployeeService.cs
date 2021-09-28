using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.BankWorkerServices.BankEmployee
{
    public class BankEmployeeService : IBankEmployeeService
    {
        public void AccountApprove(Account account)
        {
            //aynı işlemleri yapacaklar
            //status durumları update edilecek tarihleri update edilecek daha sonra veritabanında güncelleme yapıp
            throw new NotImplementedException();
        }

        public void CardApprove(Card card)
        {
            throw new NotImplementedException();
        }

        public void LoanApprove(Loan loan)
        {
            throw new NotImplementedException();
        }

        public void TransferApprove(Transfer transfer)
        {
            throw new NotImplementedException();
        }
    }
}

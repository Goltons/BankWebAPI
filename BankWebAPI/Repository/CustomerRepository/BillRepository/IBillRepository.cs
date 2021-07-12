using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.BillRepository
{
   public interface IBillRepository 
    {
        Bill getBillByBillNumber(string billNo);
    }
}

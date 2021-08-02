using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.BillService
{
    public interface IBillService
    {
        Bill PayBillFee(int cardId, string BillNumber);
        Bill GetBillByBillNumber(string BillNumber);
        List<Bill> GetPaidBills(string tcNo);
        Bill[] GetBillsByTcNo(string tcno);
        void save(Bill bill);
    }
}

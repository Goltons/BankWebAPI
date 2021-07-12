using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using BankWebAPI.Repository.CustomerRepository.BillRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.BillService
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public Bill GetBillByBillNumber(string BillNumber)
        {
            return _billRepository.getBillByBillNumber(BillNumber);
        }
        public Bill PayBillFee(string BillNumber)
        {
            Bill bill = _billRepository.getBillByBillNumber(BillNumber);
            bill.BillFee = 0
            return new Bill();
        }
    }
}

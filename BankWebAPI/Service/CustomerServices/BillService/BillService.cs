using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using BankWebAPI.Repository.CustomerRepository;
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
        private readonly ICustomerRepository _customerReository;
        public BillService(IBillRepository billRepository, ICustomerRepository customerReository)
        {
            _billRepository = billRepository;
            _customerReository = customerReository;
        }
        public Bill GetBillByBillNumber(string BillNumber)
        {
            return _billRepository.getBillByBillNumber(BillNumber);
        }

        public Bill[] GetBillsByTcNo(string tcno)
        {
            return _billRepository.GetBillsByTcNo(tcno);
        }

        public List<Bill> GetPaidBills(string tcNo)
        {
            return _billRepository.GetPaidBillsByTcNo(tcNo);
        }

        public Bill PayBillFee(string BillNumber)
        {
            Bill bill = _billRepository.getBillByBillNumber(BillNumber);
            bill.BillFee = 0;
            bill.IsApproved = true;
            _billRepository.update(bill);
            return bill;
        }

        public void save(Bill bill)
        {
            
            bill.CreatedDate = DateTime.Now;
            bill.Customer = _customerReository.GetById(bill.CustomerId);
            _billRepository.save(bill);
        }
    }
}

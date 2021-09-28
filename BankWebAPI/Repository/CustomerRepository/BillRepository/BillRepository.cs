using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankWebAPI.Repository.CustomerRepository.BillRepository
{
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepository _customerRepository;
        public BillRepository(ApplicationDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }
        public void delete(Bill entity)
        {
            throw new NotImplementedException();
        }

        public List<Bill> getAll()
        {
            throw new NotImplementedException();
        }

        public Bill getBillByBillNumber(string billNo)
        {
            
            return _context.Bills.FirstOrDefault(p => p.BillNumber == billNo);
        }
        public Bill[] GetBillsByTcNo(string tcno)
        {
            Customer customer = _customerRepository.GetByTcNo(tcno);
            return _context.Bills.Where(p => p.CustomerId == customer.CustomerId).ToArray();
        }

        public Bill GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Bill> GetPaidBillsByTcNo(string tcNo)
        {
            Customer customer = _context.Customers.FirstOrDefault(p => p.TcNo == tcNo);
            List<Bill> paidBills = (List<Bill>)_context.Bills.ToList()
                .Where(p => p.IsPaid == true && customer.TcNo == p.Customer.TcNo);
            return paidBills;
        }

        public void save(Bill entity)
        {
            _context.Bills.Add(entity);
            _context.SaveChanges();
        }

        public void update(Bill entity)
        {
            _context.Bills.Update(entity);
            _context.SaveChanges();
        }
    }
}

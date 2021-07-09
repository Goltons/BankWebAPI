using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {

        //exceptionlar yazılacak kodlar için 
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Customer CustomerGetById(int id)
        {
            Customer customer= _context.Customers.FirstOrDefault(p => 
            p.CustomerId == id);
            if (customer == null) throw new ArgumentNullException();
            return customer;
        }
        public Customer GetByTcNo(long tcNo)
        {
            Customer customer = _context.Customers.FirstOrDefault(p =>
              p.TcNo == tcNo);
            if (customer == null) throw new ArgumentNullException();
            return customer;
        }

        public void Register(Customer customer)
        {
            if (GetByTcNo(customer.TcNo) != null ) throw new AccessViolationException();
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void updateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}

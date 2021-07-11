using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        //private readonly CustomerRepository _customerRepository;
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        //jwt
        public void Login(long TcNo, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}

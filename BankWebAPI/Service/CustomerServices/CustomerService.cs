using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using BankWebAPI.Repository.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetByTcNo(string tcNo)
        {
            return _customerRepository.GetByTcNo(tcNo);
        }

        public void Login(string TcNo, string password)
        {
            //jwt kodları eklenecek 
            if (_customerRepository.GetByTcNo(TcNo) == null) throw new Exception();
            
        }

        public void Register(Customer customer)
        {
            customer.CreatedDate = DateTime.Now;
            _customerRepository.register(customer);

        }
    }
}

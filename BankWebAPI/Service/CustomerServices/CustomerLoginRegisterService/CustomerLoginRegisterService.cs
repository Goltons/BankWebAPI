using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Service.CustomerService.CustomerLoginSignInService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerService.CustomerLoginRegisterService
{
    public class CustomerLoginRegisterService : ICustomerLoginRegisterService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerLoginRegisterService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        //jwt
        public void Login(long TcNo, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(Customer customer)
        {
           _customerRepository.Register(customer);
        }
    }
}

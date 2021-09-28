using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Service.CustomerServices;
using BankWebAPI.Service.CustomerServices.LoanService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Route("/api/customer")]
    public class CustomerController:Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;   
        }
        [HttpPost]
        [Route("register")]
        public void Register([FromBody] Customer customer)
        {
            _customerService.Register(customer);

        }
        [HttpGet("{tcno}")]
        public Customer GetCustomerByTcNo(string tcno)
        {
            return _customerService.GetByTcNo(tcno);
        }
    }
}

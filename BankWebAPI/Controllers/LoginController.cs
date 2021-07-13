using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Service.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Route("/api/müşteri")]
    public class LoginController:Controller
    {
        private readonly ICustomerService _customerService;
        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        [Route("register")]
        public string  register([FromBody] Customer customer)
        {
            _customerService.Register(customer);
            return "başarı ile kayıt oldu.";
        }
        //[HttpGet]
        //public  string Login()
        //{
            
        //    return "login sayfası";
        //}
        [HttpGet("{tcno}")]
        public Customer GetCustomerByTcNo( string tcno)
        {
            
            return _customerService.GetByTcNo(tcno);
        }
    }
}

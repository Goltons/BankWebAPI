using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("/api/auth")]
    public class AuthController:Controller
    {
        private readonly ICustomerService _customerService;
        public AuthController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("login")]
        public Customer Login([FromForm] string tcNo, string Password)
        {   
            return _customerService.Login(tcNo, Password);
        }
        [HttpPost]
        public  IActionResult Authenticate([FromBody]Customer customer)
        {
            var user = _customerService.Authenticate(customer.TcNo, customer.Password);
            if (user == null)
                return BadRequest(new { message = "Kullanici veya şifre hatalı!" });
            return Ok(user);
        }
        [HttpPost]
        [Route("register")]
        public void Register([FromForm] Customer customer)
        {
            _customerService.Register(customer);

        }
    }
}

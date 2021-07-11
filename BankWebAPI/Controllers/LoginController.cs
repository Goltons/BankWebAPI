using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAPI.Controllers
{
    [Route("/api/müsteri")]
    public class LoginController:Controller
    {
        private  readonly ICustomerService _customerService;
        public LoginController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public string anasayfa()
        {
            return "anasayfa";
        }
        [HttpPost("kayit")]
        public  string login([FromBody] Customer customer)
        {
            _customerService.Register(customer);
            
            return "login sayfası";
        }
    }
}

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
        public LoginController()
        {

        }
        [HttpGet]
        public  string login()
        {
            return "login sayfası";
        }
    }
}

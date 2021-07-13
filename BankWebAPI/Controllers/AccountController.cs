
using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.AccountService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Route("/api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("save")]
        public string save([FromBody] Account account)
        {
            _accountService.AddAccount(account);
            return "hesap eklendi";
        }
        [HttpGet("/accounts")]
        public string getAccounts([FromRoute] string tcNo)
        {

            return "hesaplar getirildi";
        }

    }
}

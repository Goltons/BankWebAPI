
using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.AccountService;
using Microsoft.AspNetCore.Mvc;

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
        public string save([FromForm] Account account)
        {
            _accountService.AddAccount(account);
            return "hesap eklendi";
        }

        [HttpGet]
        [Route("{tcno}")]
        public Account[] getAccounts(string tcno)
        {
            
            return _accountService.Accounts(tcno);
            
        }

    }
}

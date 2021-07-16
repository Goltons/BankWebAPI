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
    [Route("/api/müşteri")]
    public class LoginController:Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILoanService _loanService;
        public LoginController(ICustomerService customerService, ILoanService loanService)
        {
            _customerService = customerService;
            _loanService = loanService;
        }

        [HttpGet("{tcno}")]
        public Customer GetCustomerByTcNo(string tcno)
        {
            
            return _customerService.GetByTcNo(tcno);
        }
        [HttpPost("{LoanTerm}/{amount}/{LoanType}/{interestRate}")]
        public string[] faizHesap(int LoanTerm, double amount, string LoanType, double interestRate)
        {
            return _loanService.GetPaymentPlan(LoanTerm, amount, LoanType, interestRate);
        }
    }
}

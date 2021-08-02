using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.LoanService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{   
    [Route("/api/loan")]
    public class LoanController:Controller
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }
        [HttpPost("apply")]
        public string LoanApply(Loan loan)
        {
            _loanService.LoanApply(loan);
            return "işlem başarılı";
        }
        [HttpGet("{LoanTerm}/{amount}/{interestRate}")]
        public string[] getPaymentPlan(int LoanTerm, double amount, double interestRate)
        {

            return _loanService.GetPaymentPlan(LoanTerm, amount, interestRate);
        }

    }
}

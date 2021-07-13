using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Account : BaseEntity
    {
        public Account()
        {

        }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public double TotalDeposit { get; set; }
        public double TotalDebt { get; set; }
        //[Index(IsUnique = true)]
        public int AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public Customer Customer { get; set; }
        public List<Cart> Carts { get; set; }
        public AccountType AccountType { get; set; }
    }
}

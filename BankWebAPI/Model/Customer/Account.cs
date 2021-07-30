using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public double Balance { get; set; }
        public int AccountBranchCode { get; set; }
        public double TotalDebt { get; set; }
        //[Index(IsUnique = true)]
        public int AccountNumber { get; set; }
        public string IBAN { get; set; }
        public int AccountSupplementNumber { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Card> Cards { get; set; }
        public AccountCurrencyType AccountCurrencyType { get; set; }
        public AccountType AccountType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Account : BaseEntity
    {
        public Account()
        {}
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public int AccountBranchCode { get; set; }
        public double TotalDebt { get; set; }
        public int AccountNumber { get; set; }
        public string IBAN { get; set; }
        public int AccountAdditionalNumber { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string ApproverTcNo { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Card> Cards { get; set; }
        //TRY,USD,EUR olacak şekilde 3 seçenek
        public AccountCurrencyType AccountCurrencyType { get; set; }
        //Vadeli veya Vadesiz hesap tipi
        public AccountType AccountType { get; set; }
    }
}

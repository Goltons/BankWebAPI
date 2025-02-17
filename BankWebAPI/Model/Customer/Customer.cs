﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Customer : BaseEntity
    {

        public Customer()
        {}
        [Key]
        [DisallowNull]
        public int CustomerId { get; set; }
        [StringLength(11,ErrorMessage ="11 basamak olmalı.")]
        public string TcNo { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string FatherName { get; set; }
        public string Adress { get; set; }
        [Required]
        [MaxLength(11,ErrorMessage ="11 basamak olmalı.")]
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEnable { get; set; }
        public List<Account> Accounts { get; set; }
       
        public List<Transfer> Transfers { get; set; } 
        public List<Loan> Loans { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Bill> Bills { get; set; }
        public UserRole UserRole{ get; set; }
        public string Token { get; set; }


    }
}

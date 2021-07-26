using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int CustomerId { get; set; }
        [StringLength(11,ErrorMessage ="11 basamak olmalı.")]
        [Required]
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
        [Required]
        public string Adress { get; set; }
        [Required]
        [MaxLength(11,ErrorMessage ="11 basamak olmalı.")]
        public string PhoneNumber { get; set; }
        public bool IsEnable { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Bill> Bills { get; set; }
        public UserRole UserRole{ get; set; }
        public string Token { get; set; }


    }
}

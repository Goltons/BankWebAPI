using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model.Customer
{
    public class Customer : BaseEntity
    {

        public Customer()
        {}
        [Key]
        public int CustomerId { get; set; }
        [StringLength(11)]
        [Required]
        public string TcNo { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(8)]
        public string CustomerPassword { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        public bool IsEnable { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Loan> Loans { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Bill> Bills { get; set; }


    }
}

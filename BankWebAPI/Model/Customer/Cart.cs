using System;
using System.ComponentModel.DataAnnotations;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Cart : BaseEntity
    {
        public Cart()
        {

        }
        [Key]
        public int CartId { get; set; }
        [Required]
        public int CartPassword { get; set; }
        //public string IBAN { get; set; }
        public double CartDeposit { get; set; }
        public double CartDebt { get; set; }
        public double CartLimit { get; set; }
        [StringLength(16)]
        public string CartNumber { get; set; }
        public int CVC2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastDate { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public CartType CartType { get; set; }


    }

}

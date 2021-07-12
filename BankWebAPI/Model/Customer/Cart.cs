using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [MaxLength(4)]
        public int CartPassword { get; set; }
        public string IBAN { get; set; }
        [Required]
        [MaxLength(4)]
        public int CartBranchCode { get; set; }

        public int CartSupplementNumber = 5000;
        public double CartDeposit { get; set; }
        public double CartDebt { get; set; }
        public double CartLimit = 1000;
        [MaxLength(3)]
        public int CVC2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastDate { get; set; }
        public Account Account { get; set; }
        public enum CartCurrencyType
        {
            TRY,
            USD,
            EUR
        }
        public enum CartType
        {
            DEBIT,
            CREDIT
        }


    }

}

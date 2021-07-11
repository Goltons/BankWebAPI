using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Customer
{
    public class Cart : BaseEntity
    {
        public int CartId { get; set; }
        public int CartPassword { get; set; }
        public string IBAN { get; set; }
        public int CartBranchCode { get; set; }

        public int CartSupplementNumber = 5000;
        public double CartDeposit { get; set; }
        public double CartDebt { get; set; }
        public double CartLimit = 1000;
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

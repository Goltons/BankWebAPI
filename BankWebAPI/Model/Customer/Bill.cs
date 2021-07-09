using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model.Customer
{
    public class Bill:BaseEntity
    {
        public int BillId { get; set; }
        public string BillNumber { get; set; }
        public double BillFee { get; set; }
        public bool isApproved { get; set; }
        public enum BillType
        {
            ELECTRICITY,
            WATER,
            GAS,
            PHONE,
            INTERNET
        }
    }
}

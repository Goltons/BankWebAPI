using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model.Customer
{
    public class Transaction:BaseEntity
    {
        const double feePercent = 0.001;
        public int TransactionId { get; set; }
        public double TransactionBalance { get; set; }
        public double TransactionFee { get; set; }
        public string SenderIBAN { get; set; }
        public string ReceiverIBAN { get; set; }
        public bool isApproved { get; set; }
    }
}

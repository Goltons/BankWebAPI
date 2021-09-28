using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {

        }
        public int TransactionId { get; set; }
        public double TransactionAmount { get; set; }
        public bool IsApproved { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

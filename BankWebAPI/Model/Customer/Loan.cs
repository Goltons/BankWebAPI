using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BankWebAPI.Model.Enums;

namespace BankWebAPI.Model.Customer
{
    public class Loan : BaseEntity
    {
        public Loan()
        {

        }
        const double PERSONAL_LOAN_INTEREST_RATE = 0.75;
        const double HOME_LOAN_INTEREST_RATE = 0.85;
        const double VEHICLE_LOAN_INTEREST_RATE = 0.98;
        public int LoanId { get; set; }
        public double LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPaid { get; set; }
        public double InterestRate { get; set; }
        public Customer Customer { get; set; }
        public LoanType LoanType{ get; set; }
    }
}

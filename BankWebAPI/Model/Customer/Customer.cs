using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model.Customer
{
    public class Customer:BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public long TcNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string Adress { get; set; }
        public long PhoneNumber { get; set; }
        public bool isEnable { get; set; }
        public List<Account> Accounts { get; set; }

    }
}

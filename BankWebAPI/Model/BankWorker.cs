using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model
{
    public  class BankWorker:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TcNo { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}

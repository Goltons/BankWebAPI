using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model.Customer
{
    public class BaseEntity
    {
        public DateTime CreatedDate = DateTime.Now;
        public DateTime UpdatedDAte { get; set; }
    }
}

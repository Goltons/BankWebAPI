using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.BillService
{
    public class BillService : IBillService
    {
        private readonly ApplicationDbContext _context;
        public BillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Bill GetBillByBillNumber(string BillNumber)
        {
            return _context.Bills.FirstOrDefault(p => p.BillNumber == BillNumber);
        }


        public Bill PayBillFee(string BillNumber)
        {
            throw new NotImplementedException();
        }
    }
}

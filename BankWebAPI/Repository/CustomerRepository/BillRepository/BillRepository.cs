using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.BillRepository
{
    public class BillRepository : IBaseRepository<Bill>,IBillRepository
    {
        private readonly ApplicationDbContext _context;
        public BillRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void delete(Bill entity)
        {
            throw new NotImplementedException();
        }

        public List<Bill> getAll()
        {
            throw new NotImplementedException();
        }

        public Bill getBillByBillNumber(string billNo)
        {
            return _context.Bills.FirstOrDefault(p => p.BillNumber == billNo);
        }

        public Bill GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Bill entity)
        {
            throw new NotImplementedException();
        }

        public void update(Bill entity)
        {
            throw new NotImplementedException();
        }
    }
}

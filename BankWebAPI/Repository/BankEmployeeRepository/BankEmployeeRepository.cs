using BankWebAPI.Model;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.BankEmployeeRepository
{
    public class BankEmployeeRepository : IBankEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public BankEmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void delete(BankEmployee entity)
        {
            throw new NotImplementedException();
        }

        public List<BankEmployee> getAll()
        {
            throw new NotImplementedException();
        }

        public BankEmployee GetById(int id)
        {
            return _context.BankEmployees.FirstOrDefault(p => p.Id == id);
        }

        public BankEmployee getByTcNo(string tcno)
        {
            return _context.BankEmployees.FirstOrDefault(p => p.TcNo == tcno);
        }

        public void save(BankEmployee entity)
        {
            throw new NotImplementedException();
        }

        public void update(BankEmployee entity)
        {
            throw new NotImplementedException();
        }
    }
}

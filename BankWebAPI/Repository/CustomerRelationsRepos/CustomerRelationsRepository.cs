using BankWebAPI.Model;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRelationsRepos
{
    public class CustomerRelationsRepository : ICustomerRelationsRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRelationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void delete(CustomerRelations entity)
        {
            throw new NotImplementedException();
        }

        public List<CustomerRelations> getAll()
        {
            throw new NotImplementedException();
        }

        public CustomerRelations GetById(int id)
        {
            return _context.CustomerRelations.FirstOrDefault(p => p.Id == id);
        }

        public CustomerRelations getByTcNo(string tcno)
        {
            return _context.CustomerRelations.FirstOrDefault(p => p.TcNo == tcno);
        }

        public CustomerRelations login(string tcno, string password)
        {
            return _context.CustomerRelations.FirstOrDefault(p => p.TcNo == tcno && p.Password == password);

        }

        public void save(CustomerRelations entity)
        {
            throw new NotImplementedException();
        }

        public void update(CustomerRelations entity)
        {
            throw new NotImplementedException();
        }
    }
}

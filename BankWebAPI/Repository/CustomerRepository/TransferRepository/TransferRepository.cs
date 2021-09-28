using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.TransferRepository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void delete(Transfer entity)
        {
            throw new NotImplementedException();
        }

        public List<Transfer> getAll()
        {
            throw new NotImplementedException();
        }

        public Transfer[] getAllforApprove()
        {
            return _context.Transfers.Where(p => p.IsApproved == false).ToArray();
        }

        public Transfer GetById(int id)
        {
            return _context.Transfers.FirstOrDefault(p => p.TransferId == id);
        }

        public void save(Transfer entity)
        {
            _context.Transfers.Add(entity);
            _context.SaveChanges();
        }

        public void update(Transfer entity)
        {
            _context.Transfers.Update(entity);
            _context.SaveChanges();
        }
    }
}

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

        public Transfer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Transfer entity)
        {
            throw new NotImplementedException();
        }

        public void update(Transfer entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Models.Customer;
using Repository1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository1.CustomerRepository.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository, IBaseRepository<Transaction>
    {
        public void delete(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> getAll()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public void update(Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}

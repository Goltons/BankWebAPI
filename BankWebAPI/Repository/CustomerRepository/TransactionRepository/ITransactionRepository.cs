using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.TransactionRepository
{
    interface ITransactionRepository:IBaseRepository<Transaction>
    {
        //transaction typelere göre doldurma ve geri dönüş işlem kodları yazılacak
    }
}

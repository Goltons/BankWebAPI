using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        void register(Customer customer);
        Customer GetByTcNo(string tcNo);
    }
}

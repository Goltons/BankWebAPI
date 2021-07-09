using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository
{
    interface ICustomerRepository
    {
        void Register(Customer customer);
        Customer CustomerGetById(int id);
        Customer GetByTcNo(long tcNo);
        void updateCustomer(Customer customer);
    }
}

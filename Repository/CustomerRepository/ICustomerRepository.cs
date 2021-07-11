using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository1.CustomerRepository
{
    public interface ICustomerRepository
    {
        void Register(Customer customer);
        Customer CustomerGetById(int id);
        Customer GetByTcNo(long tcNo);
        void updateCustomer(Customer customer);
    }
}

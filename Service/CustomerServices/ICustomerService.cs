using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices
{
    public interface ICustomerService
    {
        //jwt eklenecek
        void Login(long TcNo, string password);
        void Register(Customer customer);
    }
}

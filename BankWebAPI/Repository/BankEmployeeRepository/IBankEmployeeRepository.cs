using BankWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.BankEmployeeRepository
{
    public interface IBankEmployeeRepository:IBaseRepository<BankEmployee>
    {
        BankEmployee getByTcNo(string tcno);
    }
}

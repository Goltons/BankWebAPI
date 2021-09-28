using BankWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRelationsRepos
{
    public interface ICustomerRelationsRepository:IBaseRepository<CustomerRelations>
    {
        CustomerRelations getByTcNo(string tcno);
        CustomerRelations login(string tcno, string password);
    }
}

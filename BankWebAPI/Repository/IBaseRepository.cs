using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        void save(T entity);
        void delete(T entity);
        void update(T entity);
        List<T> getAll();
    }
}

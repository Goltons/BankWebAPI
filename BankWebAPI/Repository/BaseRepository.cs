using BankWebAPI.Model.Customer.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.AccountRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;
        public BaseRepository(ApplicationDbContext context)
        {
            _context=context;
            _entities = context.Set<T>();
        }
        public void delete(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> getAll()
        {
            return _entities.ToList<T>();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void save(T entity)
        {
            _context.Entry(entity);
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

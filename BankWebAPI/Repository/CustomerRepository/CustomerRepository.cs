﻿using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {

        //exceptionlar yazılacak kodlar için 
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Customer CustomerGetById(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(p =>
             p.CustomerId == id);
            if (customer == null) throw new ArgumentNullException();
            return customer;
        }

        public void delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public List<Customer> getAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByTcNo(string tcNo)
        {
            Customer customer = _context.Customers.FirstOrDefault(p =>
              p.TcNo == tcNo);
            if (customer == null) throw new ArgumentNullException();
            return customer;
        }

        public void Register(Customer customer)
        {

            _context.Add(customer);
            _context.SaveChanges();
        }

        public void register(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void save(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void updateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}

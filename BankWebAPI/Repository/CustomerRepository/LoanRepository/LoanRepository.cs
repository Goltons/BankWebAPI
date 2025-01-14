﻿using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.LoanRepository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;
        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void delete(Loan loan)
        {
            loan.IsPaid = true;
            _context.Loans.Update(loan);
        }
        public List<Loan> getAll()
        {
            throw new NotImplementedException();
        }
        public List<Loan> GetAllByTcNo(string tcNo)
        {
            return (List<Loan>)_context.Loans.ToList().Where(p => p.Customer.TcNo == tcNo);
        }
        public Loan GetById(int id)
        {
            return _context.Loans.FirstOrDefault(p => p.LoanId == id);
        }
        public Loan GetByTcNo(string tcNo)
        {
            return _context.Loans.FirstOrDefault(p => p.Customer.TcNo == tcNo);
        }
        public void save(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
        }
        public void update(Loan loan)
        {
            _context.Loans.Update(loan);
            _context.SaveChanges();
        }
    }
}

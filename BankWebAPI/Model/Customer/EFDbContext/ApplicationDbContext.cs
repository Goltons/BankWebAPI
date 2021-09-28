using BankWebAPI.Model.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankWebAPI.Model.Customer.EFDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<BankEmployee> BankEmployees { get; set; }
        public virtual DbSet<CustomerRelations> CustomerRelations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(b => b.MigrationsAssembly("BankWebAPI"));
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer
                (@"server=(localdb)\\MSSQLLocalDB;database=BankDb;Initial Catalog=master;
                        Integrated Security=True;
                        TrustServerCertificate=False;");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}

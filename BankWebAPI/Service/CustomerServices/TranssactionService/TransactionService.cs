using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.TranssactionService
{
    public class TransactionService : ITransactionService
    {
        //repository oluşturulacak
        private readonly ApplicationDbContext _context;
        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SendToIBAN(string senderIBAN, string receiverIBAN, double amount)
        {
            /*
             * repository içinde yazılacak
            Cart sender = _context.Carts.FirstOrDefault(p => p.IBAN == senderIBAN);
            Cart receiver = _context.Carts.FirstOrDefault(p => p.IBAN == receiverIBAN);
            if (sender.CartDeposit < amount) throw new Exception();
            sender.CartDeposit -= amount;
            receiver.CartDeposit += amount;
            _context.Update(sender);
            _context.Update(receiver);
            _context.SaveChanges();
            */
        }
    }
}

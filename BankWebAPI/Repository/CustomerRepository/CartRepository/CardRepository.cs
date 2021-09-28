using BankWebAPI.Model;
using BankWebAPI.Model.Customer;
using BankWebAPI.Model.Customer.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.CartRepository
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;
        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void delete(Card entity)
        {
           
            _context.Cards.Remove(entity);
            _context.SaveChanges();
        }
        public List<Card> getAll()
        {
            throw new NotImplementedException();
        }

        public Card GetByAccountId(int accountId)
        {
            return _context.Cards.FirstOrDefault(p => p.AccountId == accountId);
        }

        public Card GetById(int id)
        {
            return _context.Cards.FirstOrDefault(p => p.CardId == id);
        }
        public Card[] GetCardsByAccountId(int accountId)
        {
            return _context.Cards.Where(p => p.AccountId == accountId).ToArray();
        }

        public Card[] getCardsForApprove()
        {
            return _context.Cards.Where(p => p.IsActive == false).ToArray();
        }

        public void save(Card entity)
        {
            _context.Cards.Add(entity);
            _context.SaveChanges();
        }
        public void update(Card entity)
        {
            _context.Cards.Update(entity);
            _context.SaveChanges();
        }
    }
}

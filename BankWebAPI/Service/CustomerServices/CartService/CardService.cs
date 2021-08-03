using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using BankWebAPI.Repository.CustomerRepository.CartRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.CartService
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IAccountRepository _accountRepository;
        public CardService(ICardRepository cardRepository, IAccountRepository accountRepository)
        {
            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
        }
        public void AddNewCartToAcc(Card card)
        {
            card.CreatedDate = DateTime.Now;
            card.CVC2 = CVC2Generate();
            card.CardNumber = CardNumberGenerate();
            card.LastDate = card.CreatedDate.AddYears(4);
            _cardRepository.save(card);
        }
        public void CloseCartLimit(int id)
        {
            Card cart = _cardRepository.GetById(id);
            cart.CardLimit = 0;
            _cardRepository.update(cart);
        }
        public void DecreaseCartLimit(int id, double amaunt)
        {
            Card cart = _cardRepository.GetById(id);
            cart.CardLimit -= 100;
            _cardRepository.update(cart);
        }
        public void DeleteCartFromAccount(int id)
        {
            _cardRepository.delete(_cardRepository.GetById(id));
        }
        public string CardNumberGenerate()
        {
            Random rnd = new Random();
            string cartNumber = "";
            for (int i = 0; i < 16; i++)
            {
                int a = rnd.Next(0, 10);
                if (a == 0 && i == 0) cartNumber += rnd.Next(1, 10).ToString();
                cartNumber += a.ToString();
            }
            return cartNumber;
        }
        public int CartPasswordGenerate()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999);
        }
        public int CVC2Generate()
        {
            Random rnd = new Random();
            return rnd.Next(100, 999);
        }
        public void IncreaseCartLimit(int id, double amount)
        {
            Card cart = _cardRepository.GetById(id);
            cart.CardLimit += 100;
            _cardRepository.update(cart);
        }
        public void PayCartDebt(int id, double amountToPay)
        {
            Card cart = _cardRepository.GetById(id);
            cart.CardDebt-= amountToPay;
            _cardRepository.update(cart);
        }
        public void AddFirstCart(int accountId)
        {
            Card cartToAdd = new Card();
            //cartToAdd.CardPassword = CartPasswordGenerate();
            cartToAdd.CardNumber = CardNumberGenerate();
            cartToAdd.CVC2 = CVC2Generate();
            cartToAdd.CreatedDate = DateTime.Now;
            cartToAdd.LastDate = cartToAdd.CreatedDate.AddYears(4);
            cartToAdd.AccountId = accountId;
            cartToAdd.CardType = Model.Enums.CardType.DEBIT;
        }
        //kredi kartlarında ödenmesi gereken gecikme faizi hesaplama
        //asgari ödeme
        //limit artış onayı 
        public void CardAppealService(Card card)
        {
            card.CardNumber = CardNumberGenerate();
            card.CVC2 = CVC2Generate();
            card.CreatedDate = DateTime.Now;
            card.LastDate = card.CreatedDate.AddYears(4);
            _cardRepository.save(card);
        }
        public List<Card> getAllByTcNo(string tcno)
        {
            Account[] accounts = _accountRepository.getAllAccountsByTcNo(tcno);
            List<Card> cards = new List<Card>();

            foreach (var item in accounts)
            {
                List<Card> cardsToAdd = new List<Card>();
                cardsToAdd = _cardRepository.GetCardsByAccountId(item.AccountId).ToList();
                if (cardsToAdd.Count>0)cards.AddRange(cardsToAdd);
                           }
            return cards;
        }
    }
}

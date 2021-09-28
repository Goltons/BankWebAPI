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
        public void CloseCardLimit(int id)
        {
            Card card = _cardRepository.GetById(id);
            card.CardLimit = 0;
            _cardRepository.update(card);
        }
        public void DecreaseCardLimit(int id, double amaunt)
        {
            Card card= _cardRepository.GetById(id);
            card.CardLimit -= 100;
            _cardRepository.update(card);
        }
        public string CardNumberGenerate()
        {
            Random rnd = new Random();
            string cardNumber = "";
            for (int i = 0; i < 16; i++)
            {
                int a = rnd.Next(0, 10);
                if (a == 0 && i == 0) cardNumber += rnd.Next(1, 10).ToString();
                cardNumber += a.ToString();
            }
            return cardNumber;
        }
        public int CardPasswordGenerate()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999);
        }
        public int CVC2Generate()
        {
            Random rnd = new Random();
            return rnd.Next(100, 999);
        }
        public void IncreaseCardLimit(int id, double amount)
        {
            Card card = _cardRepository.GetById(id);
            card.CardLimit += 100;
            _cardRepository.update(card);
        }
        public void PayCardDebt(int id, double amountToPay)
        {
            Card card = _cardRepository.GetById(id);
            card.CardDebt-= amountToPay;
            _cardRepository.update(card);
        }
        public void CardAppealService(Card card)
        {
            card.CardNumber = CardNumberGenerate();
            card.CVC2 = CVC2Generate();
            card.CreatedDate = DateTime.Now;
            card.LastDate = card.CreatedDate.AddYears(4);
            card.Status = "İşleme Alındı";
            _cardRepository.save(card);
        }
        public void DeleteCardFromAccount(int id)
        {
            _cardRepository.delete(_cardRepository.GetById(id));
        }
        
        public void AddNewCardToAcc(Card card)
        {
            card.CreatedDate = DateTime.Now;
            card.CVC2 = CVC2Generate();
            card.CardNumber = CardNumberGenerate();
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
        public void AddFirstCard(int accountId)
        {
            Card cardToAdd = new Card();
            //cartToAdd.CardPassword = CartPasswordGenerate();
            cardToAdd.CardNumber = CardNumberGenerate();
            cardToAdd.CVC2 = CVC2Generate();
            cardToAdd.CreatedDate = DateTime.Now;
            cardToAdd.LastDate = cardToAdd.CreatedDate.AddYears(4);
            cardToAdd.AccountId = accountId;
            cardToAdd.CardType = Model.Enums.CardType.DEBIT;
        }

        public Card ConfirmCard(Card cardToConfirm)
        {
            if (cardToConfirm.Status == "Onaylandı")
            {
                // bir işlem yapılmasına gerek yok veritabanı güncelleme işlemini yapıyor onaylandığı için
            }
            throw new NotImplementedException();
        }

        public Card[] getAllForApprove()
        {
            return _cardRepository.getCardsForApprove();
        }
        //kredi kartlarında ödenmesi gereken gecikme faizi hesaplama
        //asgari ödeme
        //limit artış onayı
        //
    }
}

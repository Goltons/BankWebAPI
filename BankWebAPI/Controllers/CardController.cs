using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.CartService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BankWebAPI.Controllers
{
    [Route("/api/card")]
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
            {
            _cardService = cardService;
        }
        [HttpPost]
        public string save([FromBody] Card card)
        {
            _cardService.AddNewCartToAcc(card);
            return "başarı ile eklendi";
        }
       
        [HttpPost("CloseCardlimits/{id}")]
        public string CloseCardLimit(int id)
        {
            _cardService.CloseCartLimit(id);
            return "başarı ile kapatıldı";
        }
        [HttpPost("/{id}/{amount}")]
        public string PayCardDebt(int id, double amount)
        {
            _cardService.PayCartDebt(id, amount);
            return String.Format("başarı ile {0} ödendi.", amount);
        }
        [HttpGet("getCards/{tcno}")]
        public List<Card> GetCards(string tcno)
        {
            return _cardService.getAllByTcNo(tcno);
            //buna ek düzenleme refactor edilmesi gerekli kodlamanın
        }

    }
}

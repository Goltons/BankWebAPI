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
        [HttpPost("save")]
        public string save([FromForm] Card card)
        {
            _cardService.CardAppealService(card);
            return "başarı ile eklendi";
        }
        [HttpPost("CloseCardlimits/{id}")]
        public string CloseCardLimit(int id)
        {
            _cardService.CloseCardLimit(id);
            return "başarı ile kapatıldı";
        }
        [HttpPost("/{id}/{amount}")]
        public string PayCardDebt(int id, double amount)
        {   
            _cardService.PayCardDebt(id, amount);
            return String.Format("başarı ile {0} ödendi.", amount);
        }
        [HttpGet("getCards/{tcno}")]
        public Card[] GetCards(string tcno)
        {
            return _cardService.getAllByTcNo(tcno).ToArray();
        }
        [HttpGet("getall")]
        public Card[] getAllForApprove()
        {
            return _cardService.getAllForApprove();
        }
    }
}

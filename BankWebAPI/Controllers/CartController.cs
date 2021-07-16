using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.CartService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Route("/api/cart")]
    public class CartController:Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost("/save")]
        public string save([FromBody] Cart cart)
        {
            _cartService.AddNewCartToAcc(cart);
            return "başarı ile eklendi";
        }
        [HttpPost("{id}")]
        public string CloseCartLimit( int id) {
            _cartService.CloseCartLimit(id);
            return "başarı ile kapatıldı";
        }
        [HttpPost("/{id}/{amount}")]
        public string PayCartDebt(int id,double amount) {
            _cartService.PayCartDebt(id, amount);
            return String.Format("başarı ile {0} ödendi.", amount);
        }
        
        
    }
}

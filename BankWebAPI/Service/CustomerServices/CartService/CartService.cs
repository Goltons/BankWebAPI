using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository.CartRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public void AddNewCartToAcc(Cart cart)
        {
            _cartRepository.save(cart);

        }
        public void CloseCartLimit(int id)
        {
            Cart cart = _cartRepository.GetById(id);
            cart.CartLimit = 0;
            _cartRepository.update(cart);
        }
        public void DecreaseCartLimit(int id, double amaunt)
        {
            Cart cart = _cartRepository.GetById(id);
            cart.CartLimit -= 100;
            _cartRepository.update(cart);
        }
        public void DeleteCartFromAccount(int id)
        {
            _cartRepository.delete(_cartRepository.GetById(id));
        }

        public string CartNumberGenerate()
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
            Cart cart = _cartRepository.GetById(id);
            cart.CartLimit += 100;
            _cartRepository.update(cart);
        }
        public void PayCartDebt(int id, double amountToPay)
        {
            Cart cart = _cartRepository.GetById(id);
            cart.CartDebt-= amountToPay;
            _cartRepository.update(cart);
        }

        public void AddFirstCart(int accountId)
        {
            Cart cartToAdd = new Cart();
            cartToAdd.CartPassword = CartPasswordGenerate();
            cartToAdd.CartNumber = CartNumberGenerate();
            cartToAdd.CVC2 = CVC2Generate();
            cartToAdd.CreatedDate = DateTime.Now;
            cartToAdd.LastDate = cartToAdd.CreatedDate.AddYears(4);
            cartToAdd.AccountId = accountId;
            cartToAdd.CartType = Model.Enums.CartType.DEBIT;

        }
    }
}

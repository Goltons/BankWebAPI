﻿using BankWebAPI.Model.Customer;
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

    }
}

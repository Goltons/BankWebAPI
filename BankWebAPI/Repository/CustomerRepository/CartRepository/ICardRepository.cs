﻿
using BankWebAPI.Model;
using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Repository.CustomerRepository.CartRepository
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Card[] GetCardsByAccountId(int accountId);
        Card GetByAccountId(int accountId);
        Card[] getCardsForApprove();
    }
}

using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.CartService
{
    public interface ICardService
    {
        Card ConfirmCard(Card cardToConfirm);
        void AddNewCardToAcc(Card card);
        void DeleteCardFromAccount(int id);
        void CloseCardLimit(int id);
        void IncreaseCardLimit(int id, double amount);
        void DecreaseCardLimit(int id, double amount);
        void PayCardDebt(int id, double amountToPay);
        void AddFirstCard(int accountId);
        void CardAppealService(Card card);
        List<Card> getAllByTcNo(string tcno);
        Card[] getAllForApprove();
        //string IBANGenerate();

    }
}

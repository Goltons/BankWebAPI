using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using BankWebAPI.Repository.CustomerRepository.CartRepository;
using BankWebAPI.Repository.CustomerRepository.TransferRepository;
using System;

namespace BankWebAPI.Service.CustomerServices.TransferService
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICardRepository _cardRepository;

        public TransferService(ITransferRepository transferRepository, IAccountRepository accountRepository, ICustomerRepository customerRepository, ICardRepository cardRepository)
        {
            _transferRepository = transferRepository;
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _cardRepository = cardRepository;
        }
        public Transfer TransferMoney(Transfer transferEntity, int senderCardId)
        {
            //hesaba transfer eğer kart varsa karta da transfer yapıp eşitleme
            //eğer transfer edilen para tutarı 100k'dan büyükse miy onayı,
            //küçükse banka çalışanı onayı bekleyecek daha sonra transfer işlemi gerçekleşecek
            // bu kodlarda düzenleme yapılacak refactor edilecek
            if (transferEntity.TransferType == "hesap")
            {
                Account receiverAcc =
                    _accountRepository.getAccountForTransfer(transferEntity.BranchCode,
                    transferEntity.AccountNumber, transferEntity.SupplementNumber, transferEntity.ReceiverName);
                if (receiverAcc == null) return null;
                Card receiverCard = _cardRepository.GetByAccountId(receiverAcc.AccountId);
                Customer receiver = _customerRepository.GetById(receiverAcc.CustomerId);
                Card senderCard = _cardRepository.GetById(senderCardId);
                Account senderAcc = _accountRepository.GetById(senderCard.AccountId);
                Customer sender = _customerRepository.GetById(senderAcc.CustomerId);
                //veriler girildikten sonra işleme alınacak ve banka çalışanı onayı için beklenecektir.
                //gönderici->kart seçecek -> accid -> senderid alacağız.
                //alıcıya ait -> şube,hesapno,ekno,adsoyad check edip receiver id alacağız ve karta ekleyeceğiz ilk 
                //miy eklendiğinde onay için beklenecek 
                //hesabı kartı ve kullanıcıyı bulduktan sonra transferi yapıyoruz daha sonra onay için bekleyecek

                transferEntity.CreatedDate = DateTime.Now;
                transferEntity.ReceiverId = receiver.CustomerId;
                transferEntity.SenderId = sender.CustomerId;
                transferEntity.SenderIBAN = senderAcc.IBAN;
                transferEntity.ReceiverIBAN = receiverAcc.IBAN;
                if (receiverCard == null) receiverAcc.Balance += transferEntity.TransferAmount;
                receiverCard.CardBalance += transferEntity.TransferAmount;
                receiverAcc.Balance = receiverCard.CardBalance;
                senderCard.CardBalance -= transferEntity.TransferAmount;
                senderAcc.Balance = senderCard.CardBalance;
                _transferRepository.save(transferEntity);
                _cardRepository.update(senderCard);
                _cardRepository.update(receiverCard);
                return transferEntity;
                //bunları güncelle ve dene acc üzerinden yürüt kart ikinci  planda kalsın

            }
            else if (transferEntity.TransferType == "iban")
            {
                Account receiverAcc =
                    _accountRepository.getAccountForIBANTransfer(transferEntity.ReceiverIBAN, transferEntity.ReceiverName);
                if (receiverAcc == null) return null;
                Card receiverCard = _cardRepository.GetByAccountId(receiverAcc.AccountId);
                Customer receiver = _customerRepository.GetById(receiverAcc.CustomerId);
                Card senderCard = _cardRepository.GetById(senderCardId);
                Account senderAcc = _accountRepository.GetById(senderCard.AccountId);
                Customer sender = _customerRepository.GetById(senderAcc.CustomerId);

                //transfer değer atamaları
                transferEntity.CreatedDate = DateTime.Now;
                transferEntity.ReceiverId = receiver.CustomerId;
                transferEntity.SenderId = sender.CustomerId;
                transferEntity.SenderIBAN = senderAcc.IBAN;
                //iban ile transfer yapıldığı için branch code accno supp no boş bırakılacak
                receiverCard.CardBalance += transferEntity.TransferAmount;
                receiverAcc.Balance = receiverCard.CardBalance;

                senderCard.CardBalance -= transferEntity.TransferAmount;
                senderAcc.Balance = senderCard.CardBalance;

                _transferRepository.save(transferEntity);
                _cardRepository.update(senderCard);
                _cardRepository.update(receiverCard);
                return transferEntity;
            }
            return null;
        }
    }
}

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

        public Transfer[] getAllforApprove()
        {
            return _transferRepository.getAllforApprove();
        }

        public Transfer TransactionConfirm(Transfer transfer)
        {
            if (transfer.Status == "Onaylandı")
            {
                Account receiverAcc = _accountRepository.GetById(transfer.receiverAccId);
                Card receiverCard = _cardRepository.GetById(transfer.receiverCardId);
                receiverAcc.Balance += transfer.TransferAmount;
                receiverCard.CardBalance += transfer.TransferAmount;
                _accountRepository.update(receiverAcc);
                _cardRepository.update(receiverCard);
            }
            if (transfer.Status == "Onaylanmadı")
            {
                Account senderAcc = _accountRepository.GetById(transfer.senderAccId);
                Card senderCard = _cardRepository.GetById(transfer.senderCardId);
                senderAcc.Balance += transfer.TransferAmount;
                senderCard.CardBalance += transfer.TransferAmount;
                _accountRepository.update(senderAcc);
                _cardRepository.update(senderCard);
            }
            return transfer;
        }
        public Transfer TransferMoney(Transfer transferEntity, int senderCardId)
        {
            Account receiverAcc = new Account(); 
            if (transferEntity.TransferType=="hesapno")  receiverAcc =
                    _accountRepository.getAccountForTransfer(transferEntity.BranchCode,
                    transferEntity.AccountNumber, transferEntity.AdditionalNumber, transferEntity.ReceiverName);
            else  receiverAcc =
                    _accountRepository.getAccountForIBANTransfer(transferEntity.ReceiverIBAN, transferEntity.ReceiverName);
            if (receiverAcc == null) throw new ArgumentNullException();
            Card receiverCard = _cardRepository.GetByAccountId(receiverAcc.AccountId);
            Card senderCard = _cardRepository.GetById(senderCardId);
            Account senderAcc = _accountRepository.GetById(senderCard.AccountId);
            transferEntity.Status = "İşleme Alındı";
            transferEntity.CreatedDate = DateTime.Now;
            transferEntity.ReceiverId = receiverAcc.CustomerId ;
            transferEntity.SenderId = senderAcc.CustomerId;
            transferEntity.SenderIBAN = senderAcc.IBAN;
            transferEntity.ReceiverIBAN = receiverAcc.IBAN;
            transferEntity.senderAccId = senderAcc.AccountId;
            transferEntity.receiverAccId = receiverAcc.AccountId;
            transferEntity.senderCardId = senderCard.CardId;
            if(senderCard!=null)
                transferEntity.receiverCardId = receiverCard.CardId;
            //gönderici bakiyesinde düşüyoruz hem hesap hem kart bakiyesinden daha sonra veritabanını güncelliyoruz
            senderCard.CardBalance -= transferEntity.TransferAmount;
            senderAcc.Balance -= transferEntity.TransferAmount;
            //alıc  ı onay için bekleyecek
            _accountRepository.update(senderAcc);
            _transferRepository.save(transferEntity);
            _cardRepository.update(senderCard);
            _cardRepository.update(receiverCard);
            return transferEntity;
        }
    }
}
    
using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.TransferService
{
    public interface ITransferService
    {
        //veritabanına kaydetme işlemini ve onay için bekliyor gönderenin hesabından tutarı düşüyor
        Transfer TransferMoney(Transfer transferEntity, int senderCardId);
        //onay işlemini yapıp alıcıya parayı ulaştırıyor
        Transfer TransactionConfirm(Transfer transfer);
        Transfer[] getAllforApprove();


    }
}

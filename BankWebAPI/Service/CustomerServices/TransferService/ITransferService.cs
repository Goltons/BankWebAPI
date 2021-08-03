using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerServices.TransferService
{
    public interface ITransferService
    {
        Transfer TransferMoney(Transfer transferEntity, int senderCardId);
    }
}

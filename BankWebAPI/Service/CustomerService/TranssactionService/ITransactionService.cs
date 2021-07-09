using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.CustomerService.TranssactionService
{
    interface ITransactionService
    {
        void SendToIBAN(string senderIBAN ,string receiverIBAN,double amount);

    }
}

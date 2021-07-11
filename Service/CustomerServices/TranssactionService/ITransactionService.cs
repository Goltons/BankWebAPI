using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices.TranssactionService
{
    interface ITransactionService
    {
        void SendToIBAN(string senderIBAN, string receiverIBAN, double amount);

    }
}

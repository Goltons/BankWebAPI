using BankWebAPI.Model;
using BankWebAPI.Model.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Service.BankWorkerServices.CustomerRelation
{
    public interface ICustomerRelationsService
    {
         void LoanApprove(int loanId,string approverTcNo,string status);
        void AccountApprove(int accountId, string approverTcNo, string status);
        void CardApprove(int cardId, string approverTcNo, string status);
        void TransferApprove(int transferId, string approverTcNo, string status);
        CustomerRelations Authenticate(string tcno,string password);

    }
}

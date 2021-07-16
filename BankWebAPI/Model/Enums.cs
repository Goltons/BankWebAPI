using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Model
{
    public class Enums
    {

        public enum AccountType
        {
            CHECKING,
            DEPOSIT
        }
        public enum BillType
        {
            ELECTRICITY,
            WATER,
            GAS,
            PHONE,
            INTERNET
        }
        public enum CartCurrencyType
        {
            TRY,
            USD,
            EUR
        }
        public enum CartType
        {
            DEBIT,
            CREDIT
        }
        public enum LoanType
        {
            PERSONAL,
            HOME,
            VEHICLE
        }
        public enum UserRole
        {
            CUSTOMER,
            CUSTOMER_MANAGER,
            BANK_WORKER

        }
    }
}

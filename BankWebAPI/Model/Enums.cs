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
        public enum AccountCurrencyType
        {
            TRY,
            USD,
            EUR
        }
        public enum CardType
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
        public enum TransactionType{
            BILL,
            LOAN,
            TRANSFER
        }
    }
}

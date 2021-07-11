using Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.CustomerServices.BillService
{
    interface IBillService
    {
        Bill PayBillFee(string BillNumber);
        Bill GetBillByBillNumber(string BillNumber);
    }
}

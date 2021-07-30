using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.BillService;
using Microsoft.AspNetCore.Mvc;

namespace BankWebAPI.Controllers
{
    [Route("/api/bill")]
    public class BillController : Controller
    {
        public readonly IBillService _billservice;
        public BillController(IBillService billservice)
        {
            _billservice = billservice;
        }
        [HttpGet]
        [Route("{tcno}")]
        public Bill[] getAllBillsByTcno(string tcno)
        {
            return _billservice.GetBillsByTcNo(tcno);
        }
        [HttpPost("save")]
        public string saveBill([FromBody]Bill bill)
        {
            _billservice.save(bill);
            return "fatura kayıt edildi.";
        }


        //ödenmiş faturaları

        //ödenmemiş olanları getiren metodlar yazılacak 
    }
}

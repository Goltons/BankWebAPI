using BankWebAPI.Model.Customer;
using BankWebAPI.Service.CustomerServices.TransferService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Route("/api/transfer")]
    public class TransferController : Controller
    {
        private readonly ITransferService _transferService;
        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }
        [HttpPost("{cardId}")]
        public Transfer ibanTransfer([FromForm]Transfer transfer,int cardId)
        {
            return _transferService.TransferMoney(transfer, cardId);
        }
        [HttpPost("transfer/{cardId}")]
        public Transfer accountNumberTransfer([FromForm] Transfer transfer,int cardId)
        {
            return _transferService.TransferMoney(transfer, cardId);
        }
        [HttpGet("getall")]
        public Transfer[] getAllforApprove()
        {
            return _transferService.getAllforApprove();
        }
    }
}

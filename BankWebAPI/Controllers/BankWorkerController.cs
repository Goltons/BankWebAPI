using BankWebAPI.Model;
using BankWebAPI.Service.BankWorkerServices.CustomerRelation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankWebAPI.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/auth/bankworker")]
    public class BankWorkerController:Controller
    {
        private readonly ICustomerRelationsService _customerRelationsService;
        public BankWorkerController(ICustomerRelationsService customerRelationsService)
        {
            _customerRelationsService = customerRelationsService;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] CustomerRelations _customerRelations)
        {
            var user = _customerRelationsService.Authenticate(_customerRelations.TcNo, _customerRelations.Password);
            if (user == null)
                return BadRequest(new { message = "Kullanici veya şifre hatalı!" });
            return Ok(user);
        }
        [HttpGet("{transferId}/{approverTcNo}/{status}")]
        public string Transfer(int transferId,string approverTcNo,string status)
        {
            _customerRelationsService.TransferApprove(transferId, approverTcNo, status);
            return "İşlem güncellendi";

        }
    }
}

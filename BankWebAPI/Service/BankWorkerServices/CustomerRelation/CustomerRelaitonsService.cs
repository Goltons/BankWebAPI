using BankWebAPI.Helpers;
using BankWebAPI.Model;
using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRelationsRepos;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using BankWebAPI.Repository.CustomerRepository.CartRepository;
using BankWebAPI.Repository.CustomerRepository.LoanRepository;
using BankWebAPI.Repository.CustomerRepository.TransferRepository;
using BankWebAPI.Service.CustomerServices.LoanService;
using BankWebAPI.Service.CustomerServices.TransferService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPI.Service.BankWorkerServices.CustomerRelation
{
    public class CustomerRelaitonsService : ICustomerRelationsService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly ICardRepository _cardRepository;
        private readonly ITransferRepository _transferRepository;
        private readonly ITransferService _transferService;
        private readonly ICustomerRelationsRepository _customerRelationsRepository;
        private readonly AppSettings _appSettings;
        private readonly ILoanService _loanService;
        public CustomerRelaitonsService(IAccountRepository accountRepository, ILoanRepository loanRepository, ICardRepository cardRepository, ITransferRepository transferRepository, ITransferService transferService, ICustomerRelationsRepository customerRelationsRepository, IOptions<AppSettings> appSettings, ILoanService loanService)
        {
            _accountRepository = accountRepository;
            _loanRepository = loanRepository;
            _cardRepository = cardRepository;
            _transferRepository = transferRepository;
            _transferService = transferService;
            _customerRelationsRepository = customerRelationsRepository;
            _appSettings = appSettings.Value;
            _loanService = loanService;
        }
        public void AccountApprove(int accountId, string approverTcNo,string status)
        {
            Account accountToApprove = _accountRepository.GetById(accountId);
            accountToApprove.IsActive = true;
            accountToApprove.UpdatedDate = DateTime.Now;
            accountToApprove.Status = status;
            accountToApprove.ApprovedDate = DateTime.Now;
            accountToApprove.ApproverTcNo = approverTcNo;
            _accountRepository.update(accountToApprove);
        }

        public CustomerRelations Authenticate(string tcno, string password)
        {
            var user = _customerRelationsRepository.login(tcno, password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.TcNo)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            // Sifre null olarak gonderilir.
            user.Password = null;
            return user;
        }

        public void CardApprove(int cardId, string approverTcNo,string status)
        {
            Card cardToApprove = _cardRepository.GetById(cardId);
            cardToApprove.IsActive = true;
            cardToApprove.UpdatedDate = DateTime.Now;
            cardToApprove.Status = status;
            cardToApprove.ApprovedDate = DateTime.Now;
            cardToApprove.ApproverTcNo = approverTcNo;
            _cardRepository.update(cardToApprove);
        }

        public void LoanApprove(int loanId, string approverTcNo,string status)
        {
            //kredi onaylandığında hesap bakiyesine eklenecek
            Loan loanToApprove = _loanRepository.GetById(loanId);
            loanToApprove.IsApproved = true;
            loanToApprove.UpdatedDate = DateTime.Now;
            loanToApprove.Status = status;
            loanToApprove.ApprovedDate = DateTime.Now;
            loanToApprove.ApproverTcNo = approverTcNo;
            _loanRepository.update(loanToApprove);
            _loanService.ConfirmLoan(loanToApprove);
        }
        public void TransferApprove(int transferId, string approverTcNo,string status)
        {
            //transfer onayından sonra transfer işlemi gerçekleşecek
            Transfer transferToApprove = _transferRepository.GetById(transferId);
            transferToApprove.IsApproved = true;
            transferToApprove.UpdatedDate = DateTime.Now;
            transferToApprove.Status = status;
            transferToApprove.ApprovedDate = DateTime.Now;
            transferToApprove.ApproverTcNo = approverTcNo;
            _transferRepository.update(transferToApprove);
            _transferService.TransactionConfirm(transferToApprove);
        }
    }
}

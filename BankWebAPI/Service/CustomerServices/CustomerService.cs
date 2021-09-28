using BankWebAPI.Helpers;
using BankWebAPI.Model.Customer;
using BankWebAPI.Repository.CustomerRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankWebAPI.Service.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly AppSettings _appSettings;
        public CustomerService(ICustomerRepository customerRepository, IOptions<AppSettings> appSettings)
        {
            _customerRepository = customerRepository;
            _appSettings = appSettings.Value;
        }
        public Customer Authenticate(string tcNo, string customerPassword)
        {
            var customer = _customerRepository.login(tcNo, customerPassword);
            if (customer == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customer.TcNo)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            customer.Token = tokenHandler.WriteToken(token);
            // Sifre null olarak gonderilir.
            customer.Password = null;
            return customer;
        }

        public Customer GetByTcNo(string tcNo)
        {
            return _customerRepository.GetByTcNo(tcNo);
        }
        public Customer Login(string TcNo, string password)
        {

            return _customerRepository.login(TcNo, password);
            
        }
        public void Register(Customer customer)
        {
            customer.CreatedDate = DateTime.Now;
            _customerRepository.register(customer);
        }
    }
}

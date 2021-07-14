
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BankWebAPI.Service.CustomerServices;
using BankWebAPI.Model.Customer.EFDbContext;
using BankWebAPI.Repository.CustomerRepository;
using BankWebAPI.Repository.CustomerRepository.AccountRepository;
using BankWebAPI.Service.CustomerServices.AccountService;
using BankWebAPI.Repository;
using BankWebAPI.Repository.CustomerRepository.CartRepository;
using BankWebAPI.Service.CustomerServices.CartService;
using BankWebAPI.Repository.CustomerRepository.LoanRepository;
using BankWebAPI.Service.CustomerServices.LoanService;
using BankWebAPI.Service.CustomerServices.BillService;
using BankWebAPI.Repository.CustomerRepository.BillRepository;
using BankWebAPI.Repository.CustomerRepository.TransactionRepository;
using BankWebAPI.Service.CustomerServices.TranssactionService;
using BankWebAPI.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;

namespace BankWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            IdentityModelEventSource.ShowPII = true;
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // JWT authentication Aayarlaması
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });





            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddSingleton<ICartService, CartService>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddSingleton<ILoanService, LoanService>();
            services.AddSingleton<IBillService, BillService>();
            services.AddTransient<IBillRepository,BillRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<ITransactionService, TransactionService>();
            
            
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Singleton);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

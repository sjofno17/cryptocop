using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Cryptocop.Software.API.Middlewares;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Implementations;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Implementations;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var jwtConfig = Configuration.GetSection("JwtConfig");
            services.AddTransient<ITokenService>((c) =>
                new TokenService(
                    jwtConfig.GetSection("secret").Value,
                    jwtConfig.GetSection("expirationInMinutes").Value,
                    jwtConfig.GetSection("issuer").Value,
                    jwtConfig.GetSection("audience").Value));
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICryptoCurrencyService, CryptoCurrencyService>();
            services.AddTransient<IExchangeService, ExchangeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

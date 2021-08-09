using EHealth.Application.Interfaces.CardioQvark;
using EHealth.Application.Services.CardioQvark;
using EHealth.Data.CardioQvark.Interfaces;
using EHealth.Data.CardioQvark.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace EHealth.Web.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CardioQvarkOptions>(
                Configuration.GetSection("CardioQvark"));

            services.Configure<CardioQvarkDbOptions>(
                Configuration.GetSection("Database"));

            services.AddScoped<ICardioQvarkExtract, CardioQvarkExtract>();
            services.AddScoped<ICardioQvarkLoad, CardioQvarkLoad>();
            services.AddScoped<ICardioQvarkETL, CardioQvarkETL>();
            services.AddScoped<ICardioQvarkRepository, CardioQvarkRepository>();

            var cardioQvarkCert = new X509Certificate2(
                "CardioQvarkCert.p12"
                );
            var cardioQvarkHandler = new HttpClientHandler();
            cardioQvarkHandler.ClientCertificates.Add(cardioQvarkCert);
            cardioQvarkHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            services
                .AddHttpClient(CardioQvarkConstants.HttpClientName)
                .ConfigurePrimaryHttpMessageHandler(() => cardioQvarkHandler);

            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EHealth API");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

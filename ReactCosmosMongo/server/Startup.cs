using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using WebApiMongo.Contracts;
using WebApiMongo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace WebApiMongo
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
            services.AddSpaStaticFiles(config => config.RootPath = "ClientApp/build");
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<ISampleListService>(InitializeCosmosClientInstance());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            if (!env.IsDevelopment())
            {
                app.UseSpa(spa => spa.Options.SourcePath = "ClientApp");
            }
        }


        private ISampleListService InitializeCosmosClientInstance()
        {
            var connectionString = Configuration.GetConnectionString("cosmosDb");
            var cosmosSection = Configuration.GetSection("CosmosDb");
            string databaseName = cosmosSection.GetSection("DatabaseName").Value;
            string collectionName = cosmosSection.GetSection("CollectionName").Value;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);

            var cosmosDbService = new SampleListService(client, databaseName, collectionName);
    
            return cosmosDbService;
        }
    }
}

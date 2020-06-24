using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSql.Contracts;
using WebApiSql.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;

namespace WebApiSql
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
            services.AddSingleton<CosmosClient>(InitializeCosmosClientInstanceAsync().GetAwaiter().GetResult());
            services.AddSingleton<ISampleListService, SampleListService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            if (!env.IsDevelopment())
            {
                app.UseSpa(spa => spa.Options.SourcePath = "ClientApp");
            }
        }

        private async Task<CosmosClient> InitializeCosmosClientInstanceAsync()
        {
            var cosmosSection = Configuration.GetSection("CosmosDb");
            string databaseName = cosmosSection.GetSection("DatabaseName").Value;
            string containerName = cosmosSection.GetSection("ContainerName").Value;
            string account = cosmosSection.GetSection("Account").Value;
            string key = cosmosSection.GetSection("Key").Value;
            var clientBuilder = new Microsoft.Azure.Cosmos.Fluent.CosmosClientBuilder(account, key);
            var client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();
            
            var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/_partitionKey");
            return client;
        }
    }
}

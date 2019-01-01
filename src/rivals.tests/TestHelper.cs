using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using rivals.domain.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace rivals.tests
{
    public static class TestHelper
    {
        public static IServiceProvider GetServices()
        {
            var config = GetConfiguration();

            var services = new ServiceCollection();

            ConfigureDependencies(config, services);

            var provider = services.BuildServiceProvider();

            return provider;
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            var configRoot = builder
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("d7532917-963c-4279-9bec-a01090141133")
                .Build();
            return configRoot;
        }

        private static void ConfigureDependencies(IConfiguration config, IServiceCollection services)
        {
            var documentDBClient = new DocumentClient(
               new Uri(config.GetValue<String>("DocumentDB:EndpointURL")),
               config.GetValue<String>("DocumentDB:AuthKey")
           );
            services.AddSingleton<IDocumentClient>(documentDBClient);

            services.Configure<DatabaseSettings>(config.GetSection("DocumentDB"));
            services.AddOptions();

            services.AddTransient<persistence.IRepo<domain.Spike.SpikeItem>, persistence.SpikeRepo>();
            services.AddTransient<persistence.IUserSessionRepo, persistence.UserSessionRepo>();
            services.AddTransient<logic.Session.UserSessionManager>();
            services.AddTransient<persistence.IRepo<domain.Game.Duel>, persistence.DuelRepo>();
            services.AddTransient<logic.Game.DuelManager>();
        }
    }
}

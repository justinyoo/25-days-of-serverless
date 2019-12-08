using System;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using TwentyFiveDoS.Challenge22.FunctionApp.Configs;
using TwentyFiveDoS.Challenge22.FunctionApp.Services;

[assembly: FunctionsStartup(typeof(TwentyFiveDoS.Challenge22.FunctionApp.StartUp))]
namespace TwentyFiveDoS.Challenge22.FunctionApp
{
    /// <summary>
    /// This represents the entity as an IoC container.
    /// </summary>
    public class StartUp : FunctionsStartup
    {
        private const string StorageConnectionStringKey = "AzureWebJobsStorage";

        /// <inheritdoc />
        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.ConfigureAppSettings(builder.Services);
            this.ConfigureKeyVault(builder.Services);
            this.ConfigureBlobStorage(builder.Services);
            this.ConfigureServices(builder.Services);
        }

        private void ConfigureAppSettings(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();
        }

        private void ConfigureKeyVault(IServiceCollection services)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            services.AddSingleton<IKeyVaultClient>(kv);
        }

        private void ConfigureBlobStorage(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable(StorageConnectionStringKey);
            var blob = CloudStorageAccount.Parse(connectionString)
                                          .CreateCloudBlobClient();

            services.AddSingleton<CloudBlobClient>(blob);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISecretService, SecretService>();
            services.AddTransient<IBlobService, BlobService>();
        }
    }
}
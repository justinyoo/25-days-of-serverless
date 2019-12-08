using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings;
using Aliencube.AzureFunctions.Extensions.Configuration.AppSettings.Extensions;

namespace TwentyFiveDoS.Challenge22.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity.
    /// </summary>
    public class AppSettings : AppSettingsBase
    {
        private const string KeyVaultSettingsKey = "KeyVault";
        private const string BlobStorageSettingsKey = "Blob";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        public AppSettings()
        {
            this.KeyVault = this.Config.Get<KeyVaultSettings>(KeyVaultSettingsKey);
            this.Blob = this.Config.Get<BlobStorageSettings>(BlobStorageSettingsKey);
        }

        /// <summary>
        /// Gets the <see cref="KeyVaultSettings"/> instance.
        /// </summary>
        public virtual KeyVaultSettings KeyVault { get; }

        /// <summary>
        /// Gets the <see cref="BlobStorageSettings"/> instance.
        /// </summary>
        public virtual BlobStorageSettings Blob { get; }
    }
}
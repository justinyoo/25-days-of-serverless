using System.Collections.Generic;

namespace TwentyFiveDoS.Challenge22.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for Key Vault.
    /// </summary>
    public class KeyVaultSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="KeyVaultEndpointsSettings"/> instance.
        /// </summary>
        /// <value></value>
        public virtual KeyVaultEndpointsSettings Endpoints { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Dictionary{string, KeyVaultInstanceSettings}"/> instance.
        /// </summary>
        /// <value></value>
        public virtual Dictionary<string, KeyVaultInstanceSettings> Instances { get; set; }
    }
}
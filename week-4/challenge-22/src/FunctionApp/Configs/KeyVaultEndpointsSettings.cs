namespace TwentyFiveDoS.Challenge22.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for Key Vault endpoints.
    /// </summary>
    public class KeyVaultEndpointsSettings
    {
        /// <summary>
        /// Gets or sets the endpoint for backup.
        /// </summary>
        public virtual string Backup { get; set; }

        /// <summary>
        /// Gets or sets the endpoint for restore.
        /// </summary>
        public virtual string Restore { get; set; }
    }
}

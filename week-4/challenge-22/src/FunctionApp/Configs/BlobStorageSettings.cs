namespace TwentyFiveDoS.Challenge22.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for Azure Blob Storage.
    /// </summary>
    public class BlobStorageSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="BlobContainerSettings"/> instance.
        /// </summary>
        public virtual BlobContainerSettings Container { get; set; }
    }
}

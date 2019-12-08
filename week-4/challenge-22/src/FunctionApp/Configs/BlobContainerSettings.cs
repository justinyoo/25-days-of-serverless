namespace TwentyFiveDoS.Challenge22.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity for Azure Blob Container.
    /// </summary>
    public class BlobContainerSettings
    {
        /// <summary>
        /// Gets or sets the blob container name.
        /// </summary>
        public virtual string Name { get; set; }
    }
}
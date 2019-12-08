using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.KeyVault.Models;
using Microsoft.WindowsAzure.Storage.Blob;

using Newtonsoft.Json;

using TwentyFiveDoS.Challenge22.FunctionApp.Configs;

namespace TwentyFiveDoS.Challenge22.FunctionApp.Services
{
    /// <summary>
    /// This represents the service entity to handle blobs.
    /// </summary>
    public class BlobService : IBlobService
    {
        private readonly AppSettings _settings;
        private readonly CloudBlobClient _blob;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobService"/> class.
        /// </summary>
        /// <param name="settings"><see cref="AppSettings"/> instance.</param>
        /// <param name="blob"><see cref="CloudBlobClient"/> instance.</param>
        public BlobService(AppSettings settings, CloudBlobClient blob)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._blob = blob ?? throw new ArgumentNullException(nameof(blob));
        }

        /// <inheritdoc />
        public async Task<bool> UploadAsync(List<BackupSecretResult> results)
        {
            var serialised = JsonConvert.SerializeObject(results);

            var containerName = this._settings.Blob.Container.Name;
            var container = this._blob.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);

            var blobName = $"{DateTimeOffset.UtcNow.ToString("yyyyMMdd")}.json";
            var blob = container.GetBlockBlobReference(blobName);
            await blob.UploadTextAsync(serialised).ConfigureAwait(false);

            return true;
        }

        /// <inheritdoc />
        public async Task<List<BackupSecretResult>> DownloadAsync(string timestamp)
        {
            var containerName = this._settings.Blob.Container.Name;
            var container = this._blob.GetContainerReference(containerName);

            var blobName = $"{timestamp}.json";
            var blob = container.GetBlockBlobReference(blobName);
            var downloaded = await blob.DownloadTextAsync().ConfigureAwait(false);

            var results = JsonConvert.DeserializeObject<List<BackupSecretResult>>(downloaded);

            return results;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.KeyVault.Models;

namespace TwentyFiveDoS.Challenge22.FunctionApp.Services
{
    /// <summary>
    /// This provides interfaces to <see cref="BlobService"/>.
    /// </summary>
    public interface IBlobService
    {
        /// <summary>
        /// Uploads backup.
        /// </summary>
        /// <returns>Returns <c>True</c>, if upload successful; otherwise returns <c>False</c>.</returns>
        Task<bool> UploadAsync(List<BackupSecretResult> results);

        /// <summary>
        /// Downloads backup.
        /// </summary>
        /// <returns>Returns the list of <see cref="BackupSecretResult"/> instances.</returns>
        Task<List<BackupSecretResult>> DownloadAsync(string timestamp);
    }
}
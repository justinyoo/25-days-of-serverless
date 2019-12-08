using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.KeyVault.Models;

namespace TwentyFiveDoS.Challenge22.FunctionApp.Services
{
    /// <summary>
    /// This provides interfaces to <see cref="SecretService"/>.
    /// </summary>
    public interface ISecretService
    {
        /// <summary>
        /// Gets the list of secrets.
        /// </summary>
        /// <param name="key">Key Vault instance identifier.</param>
        /// <returns>Returns the list of secrets from Key Vault.</returns>
        Task<List<string>> GetSecretsAsync(string key);

        /// <summary>
        /// Performs backup secrets.
        /// </summary>
        /// <param name="key">Key Vault instance identifier.</param>
        /// <param name="secrets">List of secret names.</param>
        /// <returns>Returns the list of <see cref="BackupSecretResult"/> instances.</returns>
        Task<List<BackupSecretResult>> BackupSecretsAsync(string key, List<string> secrets);

        /// <summary>
        /// Performs restore secrets.
        /// </summary>
        /// <param name="key">Key Vault instance identifier.</param>
        /// <param name="secrets">List of <see cref="BackupSecretResult"/> instances.</param>
        /// <returns>Returns the list of secret names.</returns>
        Task<List<string>> RestoreSecretsAsync(string key, List<BackupSecretResult> secrets);
    }
}
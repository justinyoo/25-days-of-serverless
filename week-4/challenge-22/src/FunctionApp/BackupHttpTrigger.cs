using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using TwentyFiveDoS.Challenge22.FunctionApp.Services;

namespace TwentyFiveDoS.Challenge22.FunctionApp
{
    /// <summary>
    /// This represents the HTTP trigger entity to backup Key Vault secrets.
    /// </summary>
    public class BackupHttpTrigger
    {
        private readonly ISecretService _secret;
        private readonly IBlobService _blob;

        /// <summary>
        /// Creates a new instance of the <see cref="BackupHttpTrigger"/> class.
        /// </summary>
        /// <param name="secret"><see cref="ISecretService"/> instance.</param>
        /// <param name="blob"><see cref="IBlobService"/> instance.</param>
        public BackupHttpTrigger(ISecretService secret, IBlobService blob)
        {
            this._secret = secret ?? throw new ArgumentNullException(nameof(secret));
            this._blob = blob ?? throw new ArgumentNullException(nameof(blob));
        }

        /// <summary>
        /// Run backup secrets.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the list of secrets backed up.</returns>
        [FunctionName(nameof(BackupSecrets))]
        public async Task<IActionResult> BackupSecrets(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "secrets/backup")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var secrets = await this._secret.GetSecretsAsync("backup").ConfigureAwait(false);
            var results = await this._secret.BackupSecretsAsync("backup", secrets).ConfigureAwait(false);
            var uploaded = await this._blob.UploadAsync(results).ConfigureAwait(false);

            return new OkObjectResult(results);
        }
    }
}
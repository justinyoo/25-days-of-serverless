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
    public class RestoreHttpTrigger
    {
        private readonly ISecretService _secret;
        private readonly IBlobService _blob;

        /// <summary>
        /// Creates a new instance of the <see cref="RestoreHttpTrigger"/> class.
        /// </summary>
        /// <param name="secret"><see cref="ISecretService"/> instance.</param>
        /// <param name="blob"><see cref="IBlobService"/> instance.</param>
        public RestoreHttpTrigger(ISecretService secret, IBlobService blob)
        {
            this._secret = secret ?? throw new ArgumentNullException(nameof(secret));
            this._blob = blob ?? throw new ArgumentNullException(nameof(blob));
        }

        /// <summary>
        /// Run backup secrets.
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"/> instance.</param>
        /// <param name="timestamp">Timestamp value in the format of "yyyyMMdd".</param>
        /// <param name="log"><see cref="ILogger"/> instance.</param>
        /// <returns>Returns the list of secret names restored.</returns>
        [FunctionName(nameof(RestoreSecrets))]
        public async Task<IActionResult> RestoreSecrets(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "secrets/restore/{timestamp}")] HttpRequest req,
            string timestamp,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var secrets = await this._blob.DownloadAsync(timestamp).ConfigureAwait(false);
            var results = await this._secret.RestoreSecretsAsync("restore", secrets).ConfigureAwait(false);

            return new OkObjectResult(results);
        }
    }
}
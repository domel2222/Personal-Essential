using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class KeyVaultService
    {
        public async Task<string> GetSecretApiKey(string nameSecret)
        {
            var serviceClient = GetSecretClient();
            var secretResponse = await serviceClient.GetSecretAsync(nameSecret);

            return secretResponse.Value.Value;

        }
        private SecretClient GetSecretClient()
        {
            var keyVaultUri = "https://personaltestkeyvault.vault.azure.net/";

            return new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
        }
    }
}

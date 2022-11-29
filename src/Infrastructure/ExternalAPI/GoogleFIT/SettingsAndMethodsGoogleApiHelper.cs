using System.Globalization;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public static class SettingsAndMethodsGoogleApiHelper
    {

        // in the futere will be provide as environmental variables from Azure //
        public const string clientIdName = "clienIdFitnessApi";
        public const string clientSecretName = "clientSecretFitnessApi";
        //public const string clientId = (new KeyVaultService().GetSecretApiKey(clientIdName)).Result;
        //var clientSecret = new KeyVaultService().GetSecretApiKey(clientSecretName);

        public static string[] scopes = new string[]
            {
                FitnessService.Scope.FitnessActivityWrite,
                FitnessService.Scope.FitnessActivityRead,
                FitnessService.Scope.FitnessSleepRead,
                FitnessService.Scope.FitnessLocationRead,
                FitnessService.Scope.FitnessBodyRead
            };

        public static string ToRfc3339String(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo);
        }
    }
}
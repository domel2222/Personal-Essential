
using Application.Common.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Reflection;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class FitnessGoogleConnectionInitializer : IFitnessGoogleApi
    {
        private UserCredential? _userCredential;
        private FitnessService _fitnessService;

        public FitnessGoogleConnectionInitializer()
        {
            _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
  new ClientSecrets
              {
                  ClientId = ConstantSettingsApi.clientId,
                  ClientSecret = ConstantSettingsApi.clientSecret,
              },
                  ConstantSettingsApi.scopes,
                  "user",
                  CancellationToken.None,
                  new FileDataStore("Google.Fitness.Auth", false)).Result;

            _fitnessService = new FitnessService(new BaseClientService.Initializer()
            {
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name,
                HttpClientInitializer = _userCredential
            });
        }

        public IList<WeightDataPoint> GetQueryWeightPerDay(DateTime start, DateTime end)
        {
            var query = new WeightQuery(_fitnessService);
            
            return query.GetQueryWeightPerDay(start, end);
        }
    }
}

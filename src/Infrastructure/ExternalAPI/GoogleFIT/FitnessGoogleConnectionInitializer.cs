
using Application.Common.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Infrastructure.ExternalAPI.GoogleFIT.Interfaces;
using System.Reflection;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class FitnessGoogleConnectionInitializer : IWeightFitnessGoogleApi , IActiveFitnessGoogleApi
    {
        private UserCredential? _userCredential;
        private FitnessService _fitnessService;

        public FitnessGoogleConnectionInitializer()
        {
            _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
              {
                  ClientId = SettingsAndMethodsGoogleApiHelper.clientId,
                  ClientSecret = SettingsAndMethodsGoogleApiHelper.clientSecret,
              },
                  SettingsAndMethodsGoogleApiHelper.scopes,
                  "user",
                  CancellationToken.None,
                  new FileDataStore("Google.Fitness.Auth", false)).Result;

            _fitnessService = new FitnessService(new BaseClientService.Initializer()
            {
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name,
                HttpClientInitializer = _userCredential
            });
        }

        public IList<StepsData> GetQueryStepsPerDay(DateTime start, DateTime end)
        {
            var query = new ActivityQuery(_fitnessService);

            return query.GetQueryStepsPerDay(start, end);
        }

        public Task<StepsData> GetQueryStepsPerDayAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IList<WeightDataPoint> GetQueryWeightPerDay(DateTime start, DateTime end)
        {
            var query = new WeightQuery(_fitnessService);
            
            return query.GetQueryWeightPerDay(start, end);
        }


    }
}

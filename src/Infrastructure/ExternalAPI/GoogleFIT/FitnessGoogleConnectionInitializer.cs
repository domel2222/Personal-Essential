﻿
using Application.Common.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Infrastructure.ExternalAPI.GoogleFIT.DataPoint;
using Infrastructure.ExternalAPI.GoogleFIT.Interfaces;
using Infrastructure.Services;
using System.Reflection;

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class FitnessGoogleConnectionInitializer : IWeightFitnessGoogleApi , IActiveFitnessGoogleApi, ISessionFitnessGoogleApi
    {
        private UserCredential? _userCredential;
        private FitnessService _fitnessService;

        public FitnessGoogleConnectionInitializer()
        {
            _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = (new KeyVaultService()
                                    .GetSecretApiKey(SettingsAndMethodsGoogleApiHelper.clientIdName)).Result,
                    ClientSecret = (new KeyVaultService()
                                    .GetSecretApiKey(SettingsAndMethodsGoogleApiHelper.clientSecretName)).Result,
                    //ClientId = SettingsAndMethodsGoogleApiHelper.clientId,
                    //ClientSecret = SettingsAndMethodsGoogleApiHelper.clientSecret,
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

        public IList<StepsDataPoint> GetQueryStepsPerDay(DateTime start, DateTime end)
        {
            var query = new ActivityQuery(_fitnessService);

            return query.GetQueryStepsPerDay(start, end);
        }

        public Task<StepsDataPoint> GetQueryStepsPerDayAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IList<WeightDataPoint> GetQueryWeightPerDay(DateTime start, DateTime end)
        {
            var query = new WeightQuery(_fitnessService);
            
            return query.GetQueryWeightPerDay(start, end);
        }

        public IList<SessionDataPoint> GetSessionPerDay(DateTime start, DateTime end, string activityType)
        {
            var query = new SessionQuery(_fitnessService);

            return query.GetSessionPerDay(start, end, activityType);
        }
    }
}

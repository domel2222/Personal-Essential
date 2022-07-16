

namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public static class ConstantSettingsApi
    {
        public const string clientId = "508951185222-s43tqnlita9f75r07d5295nhjkigih4m.apps.googleusercontent.com";
        public const string clientSecret = "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";
        public static string[] scopes = new string[]
            {
                FitnessService.Scope.FitnessActivityWrite,
                FitnessService.Scope.FitnessActivityRead,
                FitnessService.Scope.FitnessSleepRead,
                FitnessService.Scope.FitnessLocationRead,
                FitnessService.Scope.FitnessBodyRead

            };
    }
}

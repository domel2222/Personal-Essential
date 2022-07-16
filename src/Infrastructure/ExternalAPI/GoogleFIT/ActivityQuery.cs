namespace Infrastructure.ExternalAPI.GoogleFIT
{
    public class ActivityQuery : FitnessQuery
    {
        private const string DataSourceId = "derived:com.google.step_count.delta:com.google.android.gms:estimated_steps";
        private const string DataType = "com.google.step_count.delta";
        public ActivityQuery(FitnessService fitnesService) :
                            base(fitnesService, DataSourceId, DataType)
        {
        }
    }
}

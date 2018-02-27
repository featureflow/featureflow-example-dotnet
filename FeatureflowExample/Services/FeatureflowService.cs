using Featureflow.Client;

namespace FeatureflowExample.Services
{
    public class FeatureflowService : IFeatureflowService
    {
        public FeatureflowClient Client { get; }

        public FeatureflowService()
        {
            Client = new FeatureflowClient("srv-env-5a6...your-sevrer-environment-key-here");            
        }        
        
    }
}
using Featureflow.Client;

namespace FeatureflowExample.Services
{
    public interface IFeatureflowService
    {
        FeatureflowClient Client { get; }
    }
}
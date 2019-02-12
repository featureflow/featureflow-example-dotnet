using Featureflow.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureflowWpfExample
{
    /// <summary>
    /// Wrapper for access to faetureflow client singleton
    /// </summary>
    /// <returns></returns>
    static class FeatureflowClientProvider
    {
        private static IFeatureflowClient _client;

        internal static void IntializeClient(string apiKey)
        {
            IntializeClient(apiKey, null, null);
        }

        internal static void IntializeClient(string apiKey, FeatureflowConfig config)
        {
            IntializeClient(apiKey, null, config);
        }

        internal static void IntializeClient(string apiKey, IEnumerable<Feature> predefinedFeatures)
        {
            IntializeClient(apiKey, predefinedFeatures, null);
        }

        internal static void IntializeClient(string apiKey, IEnumerable<Feature> predefinedFeatures, FeatureflowConfig config)
        {
            EnsureUninitialized();
            _client = Create(apiKey, predefinedFeatures, config);
        }

        internal static IFeatureflowClient GetClient()
        {
            EnsureInitialized();
            return _client;
        }

        private static void EnsureUninitialized()
        {
            if (_client != null)
            {
                throw new ApplicationException("Featureflow client already initialized");
            }
        }

        private static void EnsureInitialized()
        {
            if (_client == null)
            {
                throw new ApplicationException("Featureflow client must be initialized before using");
            }
        }

        private static IFeatureflowClient Create(string apiKey, IEnumerable<Feature> predefinedFeatures, FeatureflowConfig config)
        {
            return FeatureflowClientFactory.Create(apiKey, predefinedFeatures, config);
        }
    }
}

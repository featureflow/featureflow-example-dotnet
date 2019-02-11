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
        private static FeatureflowClient _client;

        internal static void IntializeClient(string apiKey)
        {
            EnsureUninitialized();
            _client = new FeatureflowClient(apiKey);
        }

        internal static void IntializeClient(string apiKey, FeatureflowConfig config)
        {
            EnsureUninitialized();
            _client = new FeatureflowClient(apiKey, null, config);
        }

        internal static void IntializeClient(string apiKey, IEnumerable<Feature> predefinedFeatures)
        {
            EnsureUninitialized();
            _client = new FeatureflowClient(apiKey, predefinedFeatures);
        }

        internal static void IntializeClient(string apiKey, IEnumerable<Feature> predefinedFeatures, FeatureflowConfig config)
        {
            EnsureUninitialized();
            _client = new FeatureflowClient(apiKey, predefinedFeatures, config);
        }

        internal static FeatureflowClient GetClient()
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
    }
}

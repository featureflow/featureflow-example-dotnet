using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeatureflowWpfExample.Views
{
    /// <summary>
    /// Interaction logic for SimpleSwitchPage.xaml
    /// </summary>
    public partial class SimpleSwitchPage : BaseExamplePage
    {
        public static DependencyProperty IsFeatureOnProperty =
            DependencyProperty.Register("IsFeatureOn", typeof(bool), typeof(SimpleSwitchPage));

        public const string ExampleFeatureKey = "is-available";

        public SimpleSwitchPage()
        {
            InitializeComponent();
        }

        protected override void Activate()
        {
            base.Activate();

            var client = FeatureflowClientProvider.GetClient();
            client.FeatureUpdated += Client_FeatureUpdated;
            UpdateFeatureValue();
        }

        protected override void Deactivate()
        {
            var client = FeatureflowClientProvider.GetClient();
            client.FeatureUpdated -= Client_FeatureUpdated;

            base.Deactivate();
        }

        public bool IsFeatureOn
        {
            get { return (bool)GetValue(IsFeatureOnProperty); }
            set { SetValue(IsFeatureOnProperty, value); }
        }

        private void Client_FeatureUpdated(Featureflow.Client.IFeatureflowClient sender, Featureflow.Client.FeatureUpdatedEventArgs args)
        {
            UpdateFeatureValue();
        }

        private void UpdateFeatureValue()
        {
            Dispatcher.InvokeAsync(() =>
            {
                IsFeatureOn = FeatureflowClientProvider.GetClient().Evaluate(ExampleFeatureKey).IsOn();
            });
        }
    }
}

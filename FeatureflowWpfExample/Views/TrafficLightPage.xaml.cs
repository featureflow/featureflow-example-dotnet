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
    /// Interaction logic for TrafficLightView.xaml
    /// </summary>
    public partial class TrafficLightView : BaseExamplePage
    {
        public const string ExampleFeatureKey = "color-set";

        public TrafficLightView()
        {
            InitializeComponent();
        }

        protected override void Activate()
        {
            base.Activate();
            FeatureflowClientProvider.GetClient().FeatureUpdated += Client_FeatureUpdated;
            UpdateFeatureValue();
        }

        public ColorFeature[] Colors { get; } = new ColorFeature[]
        {
            new ColorFeature{ Color = "red" },
            new ColorFeature{ Color = "yellow" },
            new ColorFeature{ Color = "green" },
        };

        protected override void Deactivate()
        {
            FeatureflowClientProvider.GetClient().FeatureUpdated -= Client_FeatureUpdated;
            base.Deactivate();
        }

        private void Client_FeatureUpdated(Featureflow.Client.IFeatureflowClient sender, Featureflow.Client.FeatureUpdatedEventArgs args)
        {
            if (args.FeatureKey == ExampleFeatureKey)
            {
                UpdateFeatureValue();
            }
        }

        private void UpdateFeatureValue()
        {
            Dispatcher.InvokeAsync(() =>
            {
                string value = FeatureflowClientProvider.GetClient().Evaluate(ExampleFeatureKey).Value();
                foreach (var color in Colors)
                {
                    color.IsSelected = color.Color == value;
                }
            });
        }
    }

    public class ColorFeature
        : DependencyObject
    {
        public static DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ColorFeature));

        public string Color { get; set; }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
    }
}

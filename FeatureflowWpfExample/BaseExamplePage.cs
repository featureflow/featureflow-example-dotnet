using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FeatureflowWpfExample
{
    public class BaseExamplePage
        : Page
    {
        public BaseExamplePage()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;
            Activate();
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Unloaded -= OnUnloaded;
            Deactivate();
        }

        protected virtual void Activate()
        {
        }

        protected virtual void Deactivate()
        {
        }
    }
}

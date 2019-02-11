using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FeatureflowWpfExample
{
    public class SingleEntryFrame
        : Frame
    {
        public SingleEntryFrame()
        {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;
            Navigated += SingleEntryFrame_Navigated;

            NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Unloaded -= OnUnloaded;
            Navigated -= SingleEntryFrame_Navigated;
        }

        private void SingleEntryFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace FeatureflowWpfExample.Converters
{
    public class ExampleToViewConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Example e)
            {
                string pathToXaml = null;

                switch (e.Tag)
                {
                    case ExampleTag.SimpleSwitch:
                        pathToXaml = "Views/SimpleSwitchPage.xaml";
                        break;

                    case ExampleTag.TrafficLight:
                        pathToXaml = "Views/TrafficLightPage.xaml";
                        break;
                }

                if (pathToXaml != null)
                {
                    return (Page)Application.LoadComponent(new Uri(pathToXaml, UriKind.Relative));
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

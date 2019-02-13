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

namespace FeatureflowWpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Examples = new[]
            {
                new Example
                {
                    Tag = ExampleTag.SimpleSwitch,
                    Caption = "Simple switch",
                },
                new Example
                {
                    Tag = ExampleTag.TrafficLight,
                    Caption = "Traffic light",
                },
                new Example
                {
                    Tag = ExampleTag.Other,
                    Caption = "Coming soon...",
                },
            };

            InitializeComponent();
        }

        public Example[] Examples
        {
            get;
        }
    }
}

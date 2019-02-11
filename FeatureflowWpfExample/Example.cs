using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureflowWpfExample
{
    public class Example
    {
        public ExampleTag Tag { get; set; }

        public string Caption { get; set; }
    }

    public enum ExampleTag
    {
        SimpleSwitch,
        TrafficLight,
        Other,
    }
}

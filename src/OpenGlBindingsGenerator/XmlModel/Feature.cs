using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Feature
    {
        public string Api { get; set; }
        public string Name { get; set; }
        public float Version { get; set; }
        public IDictionary<string, Enum> Enums { get; set; }
        public IDictionary<string, Group> Groups { get; set; }
        public IDictionary<string, Command> Commands { get; set; }
    }
}

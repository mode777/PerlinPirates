using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<Enum> Enums { get; set; }
    }
}

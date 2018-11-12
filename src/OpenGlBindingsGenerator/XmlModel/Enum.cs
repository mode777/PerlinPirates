using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Enum
    {
        public string Name { get; set; }
        public uint Value { get; set; }

        public string ToConstantString()
        {
            return $"public const uint {Name} = {Value};";
        }

        public string ToEnumString()
        {
            return $"{Name} = {Value}";
        }
    }
}

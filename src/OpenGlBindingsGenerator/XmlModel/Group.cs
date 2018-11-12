using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Group
    {
        public string Name { get; set; }
        public IEnumerable<Enum> Enums { get; set; }

        public string ToEnumString()
        {
            return string.Join("\n", new[]
            {
                $"public enum {Name} : uint",
                "{",
                string.Join(",\n", Enums.Select(x => x.ToEnumString())).Indent("    "),
                "}"
            });
        }
    }
}

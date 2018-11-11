using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Command
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }

        public string ToDelegateString()
        {
            return $"public delegate {ReturnType ?? "void"} {Name}({string.Join(", ", Parameters.Select(x => x.ToArgumentString()))})";
        }
    }
}

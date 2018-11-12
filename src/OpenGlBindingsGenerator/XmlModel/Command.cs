using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Command
    {

        public string Name { get; set; }
        public Parameter ReturnType { get; set; }
        public IEnumerable<Parameter> Parameters { get; set; }

        public string ToDelegateString()
        {
            return $"public {(Parameters.Any(x => x.IsPointer) ? "unsafe " : "")}delegate {ReturnType.Type ?? "void"} {Name}({string.Join(", ", Parameters.Select(x => x.ToArgumentString()))});";
        }

        public string ToDelegateDeclarationString()
        {
            return $"public readonly {Name} {Name};";
        }
    }
}

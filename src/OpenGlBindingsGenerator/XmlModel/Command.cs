using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            return $"[SuppressUnmanagedCodeSecurity] public {(Parameters.Any(x => x.IsPointer) ? "unsafe " : "")}delegate {ReturnType.Type ?? "void"} {Name}Delegate({string.Join(", ", Parameters.Select(x => x.ToArgumentString()))});";
        }

        public string ToDelegateDeclarationString()
        {
            return $"[ThreadStatic] public static {Name}Delegate {Name};";
        }

        public string ToProcLoaderString(string loaderArgument)
        {
            return $"{Name} = Marshal.GetDelegateForFunctionPointer<{Name}Delegate>({loaderArgument}(\"{Name}\"));";
        }
    }
}

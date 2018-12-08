using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace OpenGlBindingsGenerator.XmlModel
{
    public class Parameter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsPointer { get; set; }
        public bool IsGroup { get; set; }
        public string ArrayLengthParam { get; set; }
        public bool IsArray => ArrayLengthParam != null;

        public string ToArgumentString()
        {
            return $"{Type}{(IsPointer ? "*" : "")} {SafeName}";
        }

        public string SafeName
        {
            get
            {
                switch (Name)
                {
                    case "params":
                        return "@params";
                    case "string":
                        return "@string";
                    case "ref":
                        return "@ref";
                    default:
                        return Name;
                }
            }
        }
}
}

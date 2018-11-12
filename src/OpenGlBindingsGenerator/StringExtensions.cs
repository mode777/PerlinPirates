using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGlBindingsGenerator
{
    public static class StringExtensions
    {
        public static string Indent(this string str, string indent)
        {
            return indent + str.Replace("\n", "\n" + indent);
        }
    }
}

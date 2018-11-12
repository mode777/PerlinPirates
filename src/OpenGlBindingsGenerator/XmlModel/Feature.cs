using System;
using System.Collections.Generic;
using System.Linq;
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

        public string ToBindingClassString()
        {
            return string.Join("\n", new[]
            {
                "public static class GL",
                "{",
                "    #region Constants",
                string.Join("\n", Enums.Values.OrderBy(x => x.Name).Select(x => x.ToConstantString())).Indent("    "),
                "    #endregion",
                "",
                "    #region Enums",
                string.Join("\n\n", Groups.Values.OrderBy(x => x.Name).Select(x => x.ToEnumString())).Indent("    "),
                "    #endregion",
                "",
                "    #region Delegates",
                string.Join("\n", Commands.Values.OrderBy(x => x.Name).Select(x => x.ToDelegateString())).Indent("    "),
                "    #endregion",
                "",
                "    #region Delegate instances",
                string.Join("\n", Commands.Values.OrderBy(x => x.Name).Select(x => x.ToDelegateDeclarationString())).Indent("    "),
                "    #endregion",
                "}"
            });
        }
    }
}

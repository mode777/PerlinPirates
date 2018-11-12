using OpenGlBindingsGenerator.XmlModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Enum = OpenGlBindingsGenerator.XmlModel.Enum;

namespace OpenGlBindingsGenerator
{
    public class BindingGenerator
    {

        public BindingGenerator()
        {
            XDocument doc = null;

            var assembly = typeof(BindingGenerator).Assembly;

            string resourceName = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("gl.xml"));

            using (var file = assembly.GetManifestResourceStream(resourceName))
            {
                doc = XDocument.Load(file);
            }

            var enums = LoadEnums(doc);

            Enums = enums
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToDictionary(x => x.Name);
            Groups = LoadGroups(doc).ToDictionary(x => x.Name);
            Commands = LoadCommands(doc).ToDictionary(x => x.Name);
            Features = LoadFeatures(doc).ToDictionary(x => x.Name);
        }

        public IDictionary<string, Group> Groups { get; }
        public IDictionary<string, Enum> Enums { get; }
        public IDictionary<string, Command> Commands { get; }
        public IDictionary<string, Feature> Features { get; }
        
        private IEnumerable<Enum> LoadEnums(XDocument doc)
        {
            return doc.Document.Descendants("enums")
            .SelectMany(x => x.Descendants("enum").Select(y => new Enum
            {
                Name = y.Attribute("name").Value,
                Value = ParseNumber(y.Attribute("value").Value)
            }));
        }

        private IEnumerable<Group> LoadGroups(XDocument doc)
        {
            return doc.Document.Descendants("group").Select(x => new Group
            {
                Name = x.Attribute("name").Value,
                Enums = x.Descendants("enum")
               .Select(y => Enums[y.Attribute("name").Value])
               .ToArray()
            });     
        }

        private uint ParseNumber(string s)
        {
            try
            {
                if (s.StartsWith("0x"))
                    return uint.Parse(s.Substring(2), NumberStyles.AllowHexSpecifier);
                else if (s.StartsWith("-"))
                    return (uint)int.Parse(s);
                else
                    return uint.Parse(s);
            }
            catch
            {
                return default(uint);
            }
        }

        private IEnumerable<Command> LoadCommands(XDocument doc)
        {
            return doc.Document
            .Descendants("commands")
            .SelectMany(x => x.Descendants("command"))
            .Select(x =>
            {
                var proto = ParseParam(x.Descendants("proto").First());
                var parameters = x.Descendants("param");

                return new Command
                {
                    Name = proto.Name,
                    ReturnType = proto,
                    Parameters = parameters
                    .Select(y => ParseParam(y))
                    .ToArray()
                };
            });
        }

        private Parameter ParseParam(XElement el)
        {
            var para = new Parameter
            {
                Name = el.Descendants("name").First().Value,
                IsPointer = el.Value.Contains("*"),
                ArrayLengthParam = el.Attribute("len")?.Value
            };
            
            var group = el.Attribute("group")?.Value;
            para.IsGroup = group != null && Groups.ContainsKey(group);

            para.Type = para.IsGroup
                ? group
                : GetCsharpType(el.Descendants("ptype").FirstOrDefault()?.Value);
            
            if(para.Type == "IntPtr" || para.Type == "string")
            {
                para.IsPointer = false;
            }

            return para;
        }

        private string GetCsharpType(string type)
        {
            if (type == null)
                return "void";

            switch (type)
            {
                case "GLvoid":
                    return "void";
                case "GLboolean":
                    return "bool";
                case "GLubyte":
                case "GLcharARB":
                    return "byte";
                case "GLchar":
                    return "string";
                case "GLbyte":
                    return "sbyte";
                case "GLushort":
                case "GLhalfNV":
                    return "ushort";
                case "GLshort":
                case "GLhalf":
                case "GLhalfARB":
                    return "short";
                case "GLenum":
                case "GLbitfield":
                case "GLuint":
                case "GLsizeiptr":
                case "GLsizeiptrARB":
                    return "uint";
                case "GLint":
                case "GLclampx":
                case "GLsizei":
                case "GLfixed":
                    return "int";
                case "GLfloat":
                case "GLclampf":
                    return "float";
                case "GLdouble":
                case "GLclampd":
                    return "double";
                case "GLint64":
                case "GLint64EXT":
                    return "long";
                case "GLuint64":
                case "GLuint64EXT":
                    return "ulong";
                case "GLeglClientBufferEXT":
                case "GLeglImageOES":
                case "GLintptr":
                case "GLintptrARB":
                case "GLsync":
                case "GLvdpauSurfaceNV":
                case "GLhandleARB":
                case "GLVULKANPROCNV":
                case "GLDEBUGPROC":
                case "GLDEBUGPROCARB":
                case "GLDEBUGPROCKHR":
                case "GLDEBUGPROCAMD":
                case "struct _cl_context":
                case "struct _cl_event":
                    return "IntPtr";
                default:
                    throw new InvalidDataException("Unknown type: " + type);
            }
        }

        private IEnumerable<Feature> LoadFeatures(XDocument doc)
        {
            return doc.Document.Descendants("feature")
            .Select(x =>
            {
                var f = new Feature
                {
                    Name = x.Attribute("name").Value,
                    Api = x.Attribute("api").Value,
                    Version = float.Parse(x.Attribute("number").Value),
                    Enums = x.Descendants("enum")
                    .Select(y => y.Attribute("name").Value)
                    .Distinct()
                    .Select(y => Enums[y])
                    .ToDictionary(y => y.Name),
                    Commands = x.Descendants("command")
                    .Select(y => y.Attribute("name").Value)
                    .Distinct()
                    .Select(y => Commands[y])
                    .ToDictionary(y => y.Name)
                };

                // Get only used groups and filter their enum values
                f.Groups = Commands.Values
                .SelectMany(y => y.Parameters)
                .Concat(Commands.Values.Select(y => y.ReturnType))
                .Where(y => y.IsGroup)
                .Select(y => y.Type)
                .Distinct()
                .Select(y => Groups[y]).Select(y => new Group
                {
                    Name = y.Name,
                    Enums = y.Enums.Where(z => f.Enums.ContainsKey(z.Name))
                    .ToArray()
                })
                .Where(y => y.Enums.Count() > 0)
                .ToDictionary(y => y.Name);

                return f;
            });
        }
    }
}

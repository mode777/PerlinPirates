using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Game.Abstractions;

namespace Loader.Obj
{
    public class ObjLoader : ResourceLoader<ObjFile>
    {
        public override ObjFile Load(string rid, Stream stream)
        {
            if(stream == null)
                throw new FileNotFoundException(rid);

            var vertices = new List<Vector3>();
            var uvs = new List<Vector2>();
            var normals = new List<Vector3>();

            var vertexRegex = new Regex("v (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+)");
            var uvRegex = new Regex("vt (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+)");
            var normalRegex = new Regex("vn (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+)");

            using (var sr = new StreamReader(stream))
            {
                var line = sr.ReadLine();
                var c = CultureInfo.InvariantCulture;

                Vector3 ParseVec3(GroupCollection g) => new Vector3(float.Parse(g[1].Value, c), float.Parse(g[2].Value, c), float.Parse(g[3].Value, c));
                Vector2 ParseVec2(GroupCollection g) => new Vector2(float.Parse(g[1].Value, c), float.Parse(g[2].Value, c));

                while (line != null)
                {
                    var vertexMatch = vertexRegex.Match(line);
                    if (vertexMatch.Success)
                    {
                        vertices.Add(ParseVec3(vertexMatch.Groups));
                    }

                    var uvMatch = uvRegex.Match(line);
                    if (uvMatch.Success)
                    {
                        uvs.Add(ParseVec2(uvMatch.Groups));
                    }

                    var normalMatch = normalRegex.Match(line);
                    if (normalMatch.Success)
                    {
                        normals.Add(ParseVec3(normalMatch.Groups));
                    }

                    line = sr.ReadLine();
                }
            }

            return new ObjFile(vertices.ToArray(), uvs.ToArray(), normals.ToArray());
        }
    }
}
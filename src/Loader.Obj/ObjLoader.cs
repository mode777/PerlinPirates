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
            var faces = new List<Face>();

            var vertexRegex = new Regex("v (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+)");
            var uvRegex = new Regex("vt (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+)");
            var normalRegex = new Regex("vn (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+) (-?[0-9]+.[0-9]+)");
            var faceRegex = new Regex("f ([0-9]*)/([0-9]*)/([0-9]*) ([0-9]*)/([0-9]*)/([0-9]*) ([0-9]*)/([0-9]*)/([0-9]*)");

            using (var sr = new StreamReader(stream))
            {
                var line = sr.ReadLine();
                var c = CultureInfo.InvariantCulture;

                int CapToInt(Capture cap) => !String.IsNullOrWhiteSpace(cap.Value) ? int.Parse(cap.Value, c) : 0;
                float CapToFloat(Capture cap) => float.Parse(cap.Value, c);
                Vector3 ParseVec3(GroupCollection g) => new Vector3(CapToFloat(g[1]), CapToFloat(g[2]), CapToFloat(g[3]));
                Vector2 ParseVec2(GroupCollection g) => new Vector2(CapToFloat(g[1]), CapToFloat(g[2]));
                Face ParseFace(GroupCollection g) => new Face(
                    new VertexId(CapToInt(g[1]), CapToInt(g[2]), CapToInt(g[3])), 
                    new VertexId(CapToInt(g[4]), CapToInt(g[5]), CapToInt(g[6])), 
                    new VertexId(CapToInt(g[7]), CapToInt(g[8]), CapToInt(g[9])));

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

                    var faceMatch = faceRegex.Match(line);
                    if (faceMatch.Success)
                    {
                        faces.Add(ParseFace(faceMatch.Groups));
                    }

                    line = sr.ReadLine();
                }
            }

            return new ObjFile(vertices.ToArray(), uvs.ToArray(), normals.ToArray(), faces.ToArray());
        }
    }
}
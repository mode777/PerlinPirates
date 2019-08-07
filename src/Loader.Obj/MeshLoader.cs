using System.Collections.Generic;
using System.IO;
using Game.Abstractions;
using Renderer.Common3D;
using Renderer.Common3D.Primitives;
using Tgl.Net;

namespace Loader.Obj
{
    public class MeshLoader : ResourceLoader<Mesh3D>
    {
        private readonly ResourceManager _manager;
        private readonly GlContext _context;
        private readonly Shader3D _shader;

        public MeshLoader(ResourceManager manager, GlContext context, Shader3D shader)
        {
            _manager = manager;
            _context = context;
            _shader = shader;
        }

        public override Mesh3D Load(string rid, Stream stream)
        {
            var file = _manager.LoadResource<ObjFile>(rid);
            var mapping = new Dictionary<int, ushort>();

            var vertices = new List<Vertex3d>();
            var indices = new List<ushort>();

            void ParseVertex(VertexId id)
            {
                var hash = id.GetHashCode();

                if (mapping.TryGetValue(hash, out var pos))
                {
                    indices.Add(pos);
                }
                else
                {
                    indices.Add((ushort)vertices.Count);
                    mapping[hash] = (ushort)vertices.Count;

                    vertices.Add(new Vertex3d(file.Positions[id._postion], file.Normals[id._normal], file.Uvs[id._uv]));
                }
            }

            foreach (var face in file.Faces)
            {
                ParseVertex(face.A);
                ParseVertex(face.B);
                ParseVertex(face.C);
            }


            return new Mesh3D(_context, _shader, vertices.ToArray(), indices.ToArray());

        }
    }
}
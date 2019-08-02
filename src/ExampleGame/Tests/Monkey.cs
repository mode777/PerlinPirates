using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Obj;
using Renderer.Common3D;
using Renderer.Common3D.Primitives;
using Tgl.Net;
using Tgl.Net.Bindings;
using Tgl.Net.Imaging;

namespace ExampleGame.Tutorial
{
    public class Monkey : IHandlesLoad, IHandlesUpdate, IHandlesDraw
    {
        private readonly ResourceManager _resources;
        private readonly GlContext _context;
        private readonly Shader3D _shader;
        private Mesh3D _mesh;
        private Camera3D _camera;

        public Monkey(ResourceManager resources, GlContext context, Shader3D shader)
        {
            _resources = resources;
            _context = context;
            _shader = shader;
        }

        public Mesh3D LoadMesh()
        {
            var texture = _context.CreateColorTexture(ColorRgba.Parse(0x0000FFFF));
            var file = _resources.LoadResource<ObjFile>("Resources/Meshes/suzanne.obj");

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

            var material = new Material3D(texture);

            return new Mesh3D(_context, _shader, vertices.ToArray(), indices.ToArray(), material);
        }

        public void Load()
        {
            _mesh = LoadMesh();
            _camera = new Camera3D(new Vector3(4, 3, 3),
                new Vector3(0, 0, 0));
            _shader.Light1 = new Vector3(4, 4, 4);

            _context.State.DepthTest = true;
            _context.State.DepthFunc = DepthFunction.GL_LESS;
        }
        
        public void Update(float delta)
        {
            _mesh.Transform3D.Rotate(0.01f, 0.01f, 0.01f);
        }

        public void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT | ClearBufferMask.GL_DEPTH_BUFFER_BIT);

            _mesh.Draw(_camera);
        }
    }
}

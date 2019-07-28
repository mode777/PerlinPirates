using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Obj;
using Renderer.Common3D.Primitives;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace ExampleGame.Tutorial
{
    public class ObjLoading : IHandlesLoad, IHandlesUpdate, IHandlesDraw
    {
        private readonly ResourceManager _resources;
        private readonly GlContext _context;

        private IDrawable _drawable;

        private Matrix4x4 _view;
        private Matrix4x4 _model;
        private Matrix4x4 _projection;
        private Matrix4x4 _mvp;
        private float _angle;

        public ObjLoading(ResourceManager resources, GlContext context)
        {
            _resources = resources;
            _context = context;
        }

        public void Load()
        {
            var texture = _resources.LoadResource<Texture>("Resources.Textures.grid.png");
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

            _drawable = _context.BuildDrawable()
                .UseShader(x => x
                    .HasFragmentString(GL_FRAGMENT_SHADER)
                    .HasVertexString(GL_VERTEX_SHADER))
                .AddTexture("myTextureSampler", texture)
                .AddBuffer<Vertex3d>(x => x
                    .HasData(vertices.ToArray())
                    .HasAttribute("vertexPosition_modelspace", 3)
                    .HasAttribute("vertexNormal_modelspace", 3)
                    .HasAttribute("vertexUV_attr", 2))
                .UseIndices(indices.ToArray())
                .Build();

            var viewport = _context.State.Viewport;

            _projection =
                Matrix4x4.CreatePerspectiveFieldOfView(
                    ToRadians(45),
                    (float)viewport.Width / (float)viewport.Height,
                    0.1f,
                    100);

            _view = Matrix4x4.CreateLookAt(
                new Vector3(4, 3, 3),
                new Vector3(0, 0, 0),
                new Vector3(0, 1, 0));

            _model = Matrix4x4.Identity;

            _context.State.DepthTest = true;
            _context.State.DepthFunc = DepthFunction.GL_LESS;
        }
        
        

        public void Update(float delta)
        {
            _angle += 0.01f;

            _model = Matrix4x4.CreateRotationY(_angle, Vector3.Zero);

            _mvp = _model * _view * _projection;

            _drawable.Matrix4Uniforms["MVP"] = _mvp;
        }

        public void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT | ClearBufferMask.GL_DEPTH_BUFFER_BIT);

            _context.DrawDrawable(_drawable);
        }
        
        public float ToRadians(float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }

        const string GL_VERTEX_SHADER = @"
attribute vec3 vertexPosition_modelspace;
attribute vec3 vertexNormal_modelspace;
attribute vec2 vertexUV_attr;

uniform mat4 MVP;

varying  vec2 vertexUV;

void main(){

    vertexUV = vertexUV_attr;

    gl_Position = MVP * vec4(vertexPosition_modelspace, 1);
}
";

        const string GL_FRAGMENT_SHADER = @"
precision mediump float;

uniform sampler2D myTextureSampler;

varying  vec2 vertexUV;
 
void main(){

    gl_FragColor = texture2D( myTextureSampler, vertexUV );
}
";
    }
}

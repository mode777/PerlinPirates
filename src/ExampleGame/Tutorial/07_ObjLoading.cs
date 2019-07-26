using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Obj;
using Renderer.Common3D.Primitives;
using Tgl.Net;

namespace ExampleGame.Tutorial
{
    public class ObjLoading : IHandlesLoad
    {
        private readonly ResourceManager _resources;
        private readonly GlContext _context;

        public ObjLoading(ResourceManager resources, GlContext context)
        {
            _resources = resources;
            _context = context;
        }

        public void Load()
        {
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

            var drawable = _context.BuildDrawable()
                .UseShader(x => x
                    .HasFragmentString(GL_FRAGMENT_SHADER)
                    .HasVertexString(GL_VERTEX_SHADER))
                .AddBuffer<Vertex3d>(x => x
                    .HasData(vertices.ToArray())
                    .HasAttribute("vertexPosition_modelspace", 3)
                    .HasAttribute("vertexNormal_modelspace", 3)
                    .HasAttribute("vertexUV_attr", 2))
                .UseIndices(indices.ToArray())
                .Build();
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

        private const string GL_FRAGMENT_SHADER = @"
precision mediump float;

uniform sampler2D myTextureSampler;

varying  vec2 vertexUV;
 
void main(){

    gl_FragColor = texture2D( myTextureSampler, vertexUV );
}
";
    }
}

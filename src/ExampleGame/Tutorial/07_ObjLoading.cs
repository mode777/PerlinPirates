using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Game.Abstractions;
using Game.Abstractions.Events;
using Loader.Obj;

namespace ExampleGame.Tutorial
{
    public class ObjLoading : IHandlesLoad
    {
        private readonly ResourceManager _resources;

        public ObjLoading(ResourceManager resources)
        {
            _resources = resources;
        }

        public void Load()
        {
            var file = _resources.LoadResource<ObjFile>("Resources/Meshes/suzanne.obj");

            var vertices = new List<Vector3>();
            var uvs = new List<Vector3>();
            var normals = new List<Vector3>();

        }
        
        const string GL_VERTEX_SHADER = @"
attribute vec3 vertexPosition_modelspace;
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

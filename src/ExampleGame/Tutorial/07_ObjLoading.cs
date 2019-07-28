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
using Tgl.Net.Imaging;

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
        private Matrix4x4 _mv;
        private float _angle;

        public ObjLoading(ResourceManager resources, GlContext context)
        {
            _resources = resources;
            _context = context;
        }

        public void Load()
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

            _mv = _model * _view;
            _mvp = _mv * _projection;
            
            _drawable.Matrix4Uniforms["MVP"] = _mvp;
            //_drawable.Matrix4Uniforms["MV"] = _mv;
            _drawable.Matrix4Uniforms["M"] = _model;
            _drawable.Matrix4Uniforms["V"] = _view;

            var lightPos = new Vector3(4,4,4);
            _drawable.Vector3Uniforms["LightPosition_worldspace"] = lightPos;
            _drawable.Vector3Uniforms["LightPosition_worldspace_ps"] = lightPos;


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
uniform mat4 V;
uniform mat4 M;
uniform vec3 LightPosition_worldspace;

varying vec2 vertexUV;
varying vec3 Position_worldspace;
varying vec3 Normal_cameraspace;
varying vec3 EyeDirection_cameraspace;
varying vec3 LightDirection_cameraspace;

void main(){

    // Output position of the vertex, in clip space : MVP * position
    gl_Position = MVP * vec4(vertexPosition_modelspace, 1);

    // Position of the vertex, in worldspace : M * position
	Position_worldspace = (M * vec4(vertexPosition_modelspace,1)).xyz;    

    // Vector that goes from the vertex to the camera, in camera space.
	// In camera space, the camera is at the origin (0,0,0).
	vec3 vertexPosition_cameraspace = ( V * M * vec4(vertexPosition_modelspace,1)).xyz;
	EyeDirection_cameraspace = vec3(0,0,0) - vertexPosition_cameraspace;

    // Vector that goes from the vertex to the light, in camera space. M is ommited because it's identity.
	vec3 LightPosition_cameraspace = ( V * vec4(LightPosition_worldspace,1)).xyz;
	LightDirection_cameraspace = LightPosition_cameraspace + EyeDirection_cameraspace;
    
    // Normal of the the vertex, in camera space
	Normal_cameraspace = ( V * M * vec4(vertexNormal_modelspace,0)).xyz; // Only correct if ModelMatrix does not scale the model ! Use its inverse transpose if not.

    // UV of the vertex
    vertexUV = vertexUV_attr;
}
";

        const string GL_FRAGMENT_SHADER = @"
precision mediump float;

uniform sampler2D myTextureSampler;
uniform vec3 LightPosition_worldspace_ps;

varying vec2 vertexUV;
varying vec3 Position_worldspace;
varying vec3 Normal_cameraspace;
varying vec3 EyeDirection_cameraspace;
varying vec3 LightDirection_cameraspace;
 
void main(){

	// Light emission properties
	// You probably want to put them as uniforms
	vec3 LightColor = vec3(1,1,1);
	float LightPower = 50.0f;
	
	// Material properties
	vec3 MaterialDiffuseColor = texture2D( myTextureSampler, vertexUV ).rgb;
	vec3 MaterialAmbientColor = vec3(0.1,0.1,0.1) * MaterialDiffuseColor;
	vec3 MaterialSpecularColor = vec3(0.3,0.3,0.3);

	// Distance to the light
	float distance = length( LightPosition_worldspace_ps - Position_worldspace );

	// Normal of the computed fragment, in camera space
	vec3 n = normalize( Normal_cameraspace );
	// Direction of the light (from the fragment to the light)
	vec3 l = normalize( LightDirection_cameraspace );
	// Cosine of the angle between the normal and the light direction, 
	// clamped above 0
	//  - light is at the vertical of the triangle -> 1
	//  - light is perpendicular to the triangle -> 0
	//  - light is behind the triangle -> 0
	float cosTheta = clamp( dot( n,l ), 0.0, 1.0);
	
	// Eye vector (towards the camera)
	vec3 E = normalize(EyeDirection_cameraspace);
	// Direction in which the triangle reflects the light
	vec3 R = reflect(-l,n);
	// Cosine of the angle between the Eye vector and the Reflect vector,
	// clamped to 0
	//  - Looking into the reflection -> 1
	//  - Looking elsewhere -> < 1
	float cosAlpha = clamp( dot( E,R ), 0.0, 1.0);
	
	gl_FragColor = vec4(
		// Ambient : simulates indirect lighting
		MaterialAmbientColor +
		// Diffuse : color of the object
        MaterialDiffuseColor * LightColor * LightPower* cosTheta / (distance* distance) +
        // Specular : reflective highlight, like a mirror
        MaterialSpecularColor * LightColor * LightPower * pow(cosAlpha,5.0) / (distance * distance), 
    1.0);
}
";
    }
}

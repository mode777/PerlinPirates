using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Game.Abstractions;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace ExampleGame.Tutorial
{


    public class ColoredCube : GameComponent
    {
        const string GL_VERTEX_SHADER = @"
attribute vec3 vertexPosition_modelspace;
attribute vec3 vertexColor_attr;

uniform mat4 MVP;

varying  vec3 vertexColor;

void main(){

    vertexColor = vertexColor_attr;

    gl_Position = MVP * vec4(vertexPosition_modelspace, 1);
}
";

        private const string GL_FRAGMENT_SHADER = @"
precision mediump float;

varying vec3 vertexColor;

void main(){

    gl_FragColor = vec4(vertexColor, 1);
}
";

        private readonly GlContext _context;
        private readonly ResourceManager _resources;

        private IDrawable _drawable;

        private Matrix4x4 _view;
        private Matrix4x4 _model;
        private Matrix4x4 _projection;
        private Matrix4x4 _mvp;
        private float _angle;

        public ColoredCube(GlContext context, ResourceManager resources)
        {
            _context = context;
            _resources = resources;
        }

        public override void Load()
        {
            var viewport = _context.State.Viewport;

            _projection =
                Matrix4x4.CreatePerspectiveFieldOfView(
                    ToRadians(45), 
                    (float)viewport.Width / (float) viewport.Height, 
                    0.1f,
                    100);

            _view = Matrix4x4.CreateLookAt(
                new Vector3(4, 3, 3), 
                new Vector3(0, 0, 0), 
                new Vector3(0, 1, 0));

            _model = Matrix4x4.Identity;

            
            
            _drawable = _context.BuildDrawable()
                .UseShader(s => s
                    .HasFragmentString(GL_FRAGMENT_SHADER)
                    .HasVertexString(GL_VERTEX_SHADER))
                .AddUniform("MVP", _mvp)
                .AddBuffer<float>(b => b
                    .HasAttribute("vertexPosition_modelspace", 3)
                    .HasData(Cube))
                .AddBuffer<float>(b => b
                    .HasAttribute("vertexColor_attr", 3)
                    .HasData(CubeColors))
                .Build();

            _context.State.DepthTest = true;
            _context.State.DepthFunc = DepthFunction.GL_LESS;
        }

        public override void Update(float delta)
        {
            _angle += 0.01f;

            _model = Matrix4x4.CreateRotationY(_angle, Vector3.Zero);

            _mvp = _model * _view * _projection;

            _drawable.Matrix4Uniforms["MVP"] = _mvp;
        }


        public override void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT | ClearBufferMask.GL_DEPTH_BUFFER_BIT);

            _context.DrawDrawable(_drawable);
        }

        public float ToRadians(float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }

        private static readonly float[] CubeColors =
        {
            0.583f, 0.771f, 0.014f,
            0.609f, 0.115f, 0.436f,
            0.327f, 0.483f, 0.844f,
            0.822f, 0.569f, 0.201f,
            0.435f, 0.602f, 0.223f,
            0.310f, 0.747f, 0.185f,
            0.597f, 0.770f, 0.761f,
            0.559f, 0.436f, 0.730f,
            0.359f, 0.583f, 0.152f,
            0.483f, 0.596f, 0.789f,
            0.559f, 0.861f, 0.639f,
            0.195f, 0.548f, 0.859f,
            0.014f, 0.184f, 0.576f,
            0.771f, 0.328f, 0.970f,
            0.406f, 0.615f, 0.116f,
            0.676f, 0.977f, 0.133f,
            0.971f, 0.572f, 0.833f,
            0.140f, 0.616f, 0.489f,
            0.997f, 0.513f, 0.064f,
            0.945f, 0.719f, 0.592f,
            0.543f, 0.021f, 0.978f,
            0.279f, 0.317f, 0.505f,
            0.167f, 0.620f, 0.077f,
            0.347f, 0.857f, 0.137f,
            0.055f, 0.953f, 0.042f,
            0.714f, 0.505f, 0.345f,
            0.783f, 0.290f, 0.734f,
            0.722f, 0.645f, 0.174f,
            0.302f, 0.455f, 0.848f,
            0.225f, 0.587f, 0.040f,
            0.517f, 0.713f, 0.338f,
            0.053f, 0.959f, 0.120f,
            0.393f, 0.621f, 0.362f,
            0.673f, 0.211f, 0.457f,
            0.820f, 0.883f, 0.371f,
            0.982f, 0.099f, 0.879f
        };

        private static readonly float[] Cube =
        {
            -1.0f, -1.0f, -1.0f, // triangle 1 : begin
            -1.0f, -1.0f, 1.0f,
            -1.0f, 1.0f, 1.0f, // triangle 1 : end
            1.0f, 1.0f, -1.0f, // triangle 2 : begin
            -1.0f, -1.0f, -1.0f,
            -1.0f, 1.0f, -1.0f, // triangle 2 : end
            1.0f, -1.0f, 1.0f,
            -1.0f, -1.0f, -1.0f,
            1.0f, -1.0f, -1.0f,
            1.0f, 1.0f, -1.0f,
            1.0f, -1.0f, -1.0f,
            -1.0f, -1.0f, -1.0f,
            -1.0f, -1.0f, -1.0f,
            -1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f, -1.0f,
            1.0f, -1.0f, 1.0f,
            -1.0f, -1.0f, 1.0f,
            -1.0f, -1.0f, -1.0f,
            -1.0f, 1.0f, 1.0f,
            -1.0f, -1.0f, 1.0f,
            1.0f, -1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            1.0f, -1.0f, -1.0f,
            1.0f, 1.0f, -1.0f,
            1.0f, -1.0f, -1.0f,
            1.0f, 1.0f, 1.0f,
            1.0f, -1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            1.0f, 1.0f, -1.0f,
            -1.0f, 1.0f, -1.0f,
            1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f, -1.0f,
            -1.0f, 1.0f, 1.0f,
            1.0f, 1.0f, 1.0f,
            -1.0f, 1.0f, 1.0f,
            1.0f, -1.0f, 1.0f
        };
    }
}

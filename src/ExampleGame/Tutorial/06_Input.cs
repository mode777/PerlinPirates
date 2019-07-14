using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Game.Abstractions;
using Game.Abstractions.Constants;
using Game.Abstractions.Events;
using Microsoft.Extensions.Logging;
using Tgl.Net;
using Tgl.Net.Bindings;

namespace ExampleGame.Tutorial
{


    public class Input : IHandlesLoad, IHandlesDraw, IHandlesUpdate
    {
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

        private readonly GlContext _context;
        private readonly ResourceManager _resources;
        private readonly InputState _state;
        private readonly IPlatform _platform;
        private readonly ILogger<Input> _logger;

        private IDrawable _drawable;

        private Matrix4x4 _view;
        private Matrix4x4 _model;
        private Matrix4x4 _projection;
        private Matrix4x4 _mvp;

        private Vector3 _postion = new Vector3(0, 0, 5);
        private Vector3 _direction = new Vector3();
        private float _hAngle = 3.14f;
        private float _vAngle = 0;
        private float _initalFoV = 45;
        private float _speed = 3;
        private float _mouseSpeed = 0.1f;
        private Vector3 _up = new Vector3(0, 1, 0);
        
        private float _delta;


        public Input(GlContext context, ResourceManager resources, InputState state, IPlatform platform, ILogger<Input> logger)
        {
            _context = context;
            _resources = resources;
            _state = state;
            _platform = platform;
            _logger = logger;
        }

        public void Load()
        {
            var texture = _resources.LoadResource<Texture>("Resources.Textures.grid.png");

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

            _drawable = _context.BuildDrawable()
                .UseShader(s => s
                    .HasFragmentString(GL_FRAGMENT_SHADER)
                    .HasVertexString(GL_VERTEX_SHADER))
                .AddUniform("MVP", _mvp)
                .AddTexture("myTextureSampler", texture)
                .AddBuffer<float>(b => b
                    .HasAttribute("vertexPosition_modelspace", 3)
                    .HasData(Cube))
                .AddBuffer<float>(b => b
                    .HasAttribute("vertexUV_attr", 2)
                    .HasData(CubeUVs))
                .Build();

            _context.State.DepthTest = true;
            _context.State.DepthFunc = DepthFunction.GL_LESS;
            _context.State.CullFace = true;
            _context.State.CullFaceMode = CullFaceMode.GL_BACK;
        }

        public void Update(float delta)
        {
            var halfWindow = _context.DefaultViewport.Size / 2;

            var pos = _platform.GetMousePosition();
            _hAngle += _mouseSpeed * delta * (halfWindow.Width - pos.X);
            _vAngle += _mouseSpeed * delta * (halfWindow.Height - pos.Y);
            _platform.SetMousePosition(new Point(halfWindow));
            
            _direction = new Vector3(
                (float)(Math.Cos(_vAngle) * Math.Sin(_hAngle)),
                (float)Math.Sin(_vAngle),
                (float)(Math.Cos(_vAngle) * Math.Cos(_hAngle)));

            var right = new Vector3((float)Math.Sin(_hAngle - 3.14f/2f), 0, (float)Math.Cos(_hAngle - 3.14f/2f));
            _up = Vector3.Cross(right, _direction);

            if (_state.IsKeyDown(KeyCode.w))
            {
                _postion += _direction * _delta * _speed;
            }
            else if (_state.IsKeyDown(KeyCode.s))
            {
                _postion -= _direction * _delta * _speed;
            }

            if (_state.IsKeyDown(KeyCode.a))
            {
                _postion -= right * delta * _speed;
            }
            else if (_state.IsKeyDown(KeyCode.d))
            {
                _postion += right * delta * _speed;
            }

            _delta = delta;

            _view = Matrix4x4.CreateLookAt(_postion, _postion + _direction, _up);

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

        private static readonly float[] CubeUVs =
        {
            0.000059f, 1.0f-0.000004f,
            0.000103f, 1.0f-0.336048f,
            0.335973f, 1.0f-0.335903f,
            1.000023f, 1.0f-0.000013f,
            0.667979f, 1.0f-0.335851f,
            0.999958f, 1.0f-0.336064f,
            0.667979f, 1.0f-0.335851f,
            0.336024f, 1.0f-0.671877f,
            0.667969f, 1.0f-0.671889f,
            1.000023f, 1.0f-0.000013f,
            0.668104f, 1.0f-0.000013f,
            0.667979f, 1.0f-0.335851f,
            0.000059f, 1.0f-0.000004f,
            0.335973f, 1.0f-0.335903f,
            0.336098f, 1.0f-0.000071f,
            0.667979f, 1.0f-0.335851f,
            0.335973f, 1.0f-0.335903f,
            0.336024f, 1.0f-0.671877f,
            1.000004f, 1.0f-0.671847f,
            0.999958f, 1.0f-0.336064f,
            0.667979f, 1.0f-0.335851f,
            0.668104f, 1.0f-0.000013f,
            0.335973f, 1.0f-0.335903f,
            0.667979f, 1.0f-0.335851f,
            0.335973f, 1.0f-0.335903f,
            0.668104f, 1.0f-0.000013f,
            0.336098f, 1.0f-0.000071f,
            0.000103f, 1.0f-0.336048f,
            0.000004f, 1.0f-0.671870f,
            0.336024f, 1.0f-0.671877f,
            0.000103f, 1.0f-0.336048f,
            0.336024f, 1.0f-0.671877f,
            0.335973f, 1.0f-0.335903f,
            0.667969f, 1.0f-0.671889f,
            1.000004f, 1.0f-0.671847f,
            0.667979f, 1.0f-0.335851f
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

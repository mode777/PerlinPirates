﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Game.Abstractions;
using Tgl.Net;

namespace ExampleGame.Tutorial
{


    public class Matrices : GameComponent
    {
        const string GL_VERTEX_SHADER = @"
attribute vec3 vertexPosition_modelspace;

uniform mat4 MVP;

void main(){
    gl_Position = MVP * vec4(vertexPosition_modelspace, 1);
}
";

        private const string GL_FRAGMENT_SHADER = @"
void main(){
    gl_FragColor = vec4(1,0,0,1);
}
";

        private readonly GlContext _context;
        private readonly ResourceManager _resources;

        private IDrawable _drawable;

        private Matrix4x4 _view;
        private Matrix4x4 _model;
        private Matrix4x4 _projection;
        private Matrix4x4 _mvp;

        public Matrices(GlContext context, ResourceManager resources)
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

            _mvp = _model * _view * _projection;
            
            _drawable = _context.BuildDrawable()
                .UseShader(s => s
                    .HasFragmentString(GL_FRAGMENT_SHADER)
                    .HasVertexString(GL_VERTEX_SHADER))
                .AddUniformSetter("MVP", s => s.SetUniform(s.GetUniformLocation("MVP"), _mvp))
                //.AddUniform("MVP", _mvp)
                .AddBuffer<float>(b => b
                    .HasAttribute("vertexPosition_modelspace", 3)
                    .HasData(-1.0f, -1.0f, 0.0f,
                        1.0f, -1.0f, 0.0f,
                        0.0f, 1.0f, 0.0f))
                .Build();
        }


        public override void Draw()
        {
            _context.DrawDrawable(_drawable);
        }

        public float ToRadians(float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }
    }
}

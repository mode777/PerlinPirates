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
        private Material3D _material;

        public Monkey(ResourceManager resources, GlContext context, Shader3D shader)
        {
            _resources = resources;
            _context = context;
            _shader = shader;
        }

        public void Load()
        {
            _mesh = _resources.LoadResource<Mesh3D>("Resources/Meshes/suzanne.obj");
            _camera = new Camera3D(new Vector3(4, 1, 0),
                new Vector3(0, 0, 0));
            _shader.Light1 = new Light(new Vector3(4, 4, 4), new Vector3(1,0.8f,0.8f), 100);
            var texture = _context.CreateColorTexture(ColorRgba.Parse(0x0000FFFF));
            _material = new Material3D(texture);

                _context.State.DepthTest = true;
            _context.State.DepthFunc = DepthFunction.GL_LESS;
            _context.State.CullFace = true;
            _context.State.CullFaceMode = CullFaceMode.GL_BACK;
        }
        
        public void Update(float delta)
        {
            _mesh.Transform3D.Rotate(0.01f, 0, 0);
        }

        public void Draw()
        {
            _context.Clear(ClearBufferMask.GL_COLOR_BUFFER_BIT | ClearBufferMask.GL_DEPTH_BUFFER_BIT);

            _mesh.Draw(_camera, _material);
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;
//using Game.Abstractions;
//using Tgl.Net;

//namespace ExampleGame.Tutorial
//{


//    public class FirstTriangle : GameComponent
//    {
//        const string GL_VERTEX_SHADER = @"
//attribute vec3 vertexPosition_modelspace;

//void main(){
//    gl_Position.xyz = vertexPosition_modelspace;
//    gl_Position.w = 1.0;
//}
//";

//        private const string GL_FRAGMENT_SHADER = @"
//void main(){
//    gl_FragColor = vec4(1,0,0,1);
//}
//";

//        private readonly GlContext _context;
//        private readonly ResourceManager _resources;

//        private IDrawable _drawable;

//        public FirstTriangle(GlContext context, ResourceManager resources)
//        {
//            _context = context;
//            _resources = resources;
//        }

//        public override void Load()
//        {
//            _drawable = _context.BuildDrawable()
//                .UseShader(s => s
//                    .HasFragmentString(GL_FRAGMENT_SHADER)
//                    .HasVertexString(GL_VERTEX_SHADER))
//                .AddBuffer<float>(b => b
//                    .HasAttribute("vertexPosition_modelspace", 3)
//                    .HasData(-1.0f, -1.0f, 0.0f,
//                        1.0f, -1.0f, 0.0f,
//                        0.0f, 1.0f, 0.0f))
//                .Build();
//        }

//        public override void Draw()
//        {
//            _context.DrawDrawable(_drawable);
//        }
//    }
//}

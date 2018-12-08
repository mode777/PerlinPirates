//using System;
//using System.Collections.Generic;
//using System.Text;
//using Tgl.Net.Math;

//namespace Tgl.Net.Core
//{
//    public class TglContext
//    {
//        private readonly TglState _state = new TglState();

//        public TglContext(Func<string, IntPtr> getProcAddress)
//        {
//            GL.LoadApi(getProcAddress);
//        }

//        public TglState State => _state;

//        public void Clear(GL.ClearBufferMask flags)
//        {
//            GL.glClear(flags);
//        }

//        public void Clear(GL.ClearBufferMask flags, Vertex4f color)
//        {
//            _state.ClearColor.Set(color);
//            Clear(flags);
//        }
//    }
//}

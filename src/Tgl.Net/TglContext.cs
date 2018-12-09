using System;
using Tgl.Net.Math;
using static Tgl.Net.GL;

namespace Tgl.Net.Core
{
    public class TglContext
    {
        private readonly TglState _state = new TglState();

        public TglContext(Func<string, IntPtr> getProcAddress)
        {
            LoadApi(getProcAddress);
        }

        public TglState State => _state;

        public void Clear(ClearBufferMask flags)
        {
            glClear(flags);
        }

        public void Clear(ClearBufferMask flags, Color color)
        {
            _state.ClearColor.Set(color);
            Clear(flags);
        }
    }
}

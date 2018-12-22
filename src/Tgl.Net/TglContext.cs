﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tgl.Net.Math;
using static Tgl.Net.GL;

namespace Tgl.Net.Core
{
    public class TglContext
    {
        private readonly CachedState _state;

        public TglContext(Func<string, IntPtr> getProcAddress)
        {
            LoadApi(getProcAddress);
            _state = new CachedState();
        }

        public CachedState State => _state;

        public void Clear(ClearBufferMask flags)
        {
            glClear(flags);
        }

        public void Clear(ClearBufferMask flags, Vector4 color)
        {
            _state.ColorClearValue = color;
            Clear(flags);
        }

        public IEnumerable<ErrorCode> GetError()
        {
            ErrorCode e;
            do
            {
                e = glGetError();
                yield return e;
            } while (e != ErrorCode.GL_NO_ERROR);
        }
    }
}

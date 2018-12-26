using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tgl.Net.Helpers
{

    // Source: http://faithlife.codes/blog/2010/05/pinned_gchandle_wrapper/
    public struct PinnedGCHandle : IDisposable
    {
        private readonly GCHandle _handle;

        public PinnedGCHandle(object obj)
        {
            _handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
        }

        public void Dispose()
        {
            if (_handle.IsAllocated)
                _handle.Free();
        }

        public IntPtr Pointer
        {
            get { return _handle.AddrOfPinnedObject(); }
        }

        public static implicit operator IntPtr(PinnedGCHandle handle)
        {

            return handle.Pointer;
        }

    }
}

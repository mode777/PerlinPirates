using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Loader.Obj
{
    public class VertexAttributeCollection<T> : IEnumerable<T>
    {
        private readonly List<T> _list;

        public VertexAttributeCollection(List<T> list)
        {
            _list = list;
        }

        public T this[int index] => index != 0 
            ? _list[index - 1]
            : default;

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _list).GetEnumerator();
        }
    }

    public struct VertexId
    {
        public readonly int _postion;
        public readonly int _uv;
        public readonly int _normal;

        public VertexId(int postion, int uv, int normal)
        {
            _postion = postion;
            _uv = uv;
            _normal = normal;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _postion.GetHashCode();
                hash = hash * 23 + _uv.GetHashCode();
                hash = hash * 23 + _normal.GetHashCode();
                return hash;
            }
        }
    }

    public class Face
    {
        public VertexId A { get; }
        public VertexId B { get; }
        public VertexId C { get; }

        public Face(VertexId a, VertexId b, VertexId c)
        {
            A = a;
            B = b;
            C = c;
        }
    }

    public class ObjFile
    {
        private readonly Face[] _faces;

        public ObjFile(IEnumerable<Vector3> positions, IEnumerable<Vector2> uvs, IEnumerable<Vector3> normals, Face[] faces)
        {
            _faces = faces;

            Positions = new VertexAttributeCollection<Vector3>(positions.ToList());
            Uvs = new VertexAttributeCollection<Vector2>(uvs.ToList());
            Normals = new VertexAttributeCollection<Vector3>(normals.ToList());
        }

        public VertexAttributeCollection<Vector3> Positions { get; }
        public VertexAttributeCollection<Vector2> Uvs { get; }
        public VertexAttributeCollection<Vector3> Normals { get; }
        public IEnumerable<Face> Faces => _faces.AsEnumerable();
    }
}

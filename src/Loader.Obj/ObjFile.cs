using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Loader.Obj
{
    public class ObjFile
    {
        private readonly Vector3[] _positions;
        private readonly Vector2[] _uvs;
        private readonly Vector3[] _normals;

        public ObjFile(Vector3[] positions, Vector2[] uvs, Vector3[] normals)
        {
            _positions = positions;
            _uvs = uvs;
            _normals = normals;
        }

        private IEnumerable<Vector3> Positions => _positions.AsEnumerable();
        private IEnumerable<Vector2> Uvs => _uvs.AsEnumerable();
        private IEnumerable<Vector3> Normals => _normals.AsEnumerable();
    }
}

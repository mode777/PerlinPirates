using System;
using System.Collections.Generic;
using System.Text;
using Tgl.Net.Math;

namespace Renderer.Gles2
{
    public class Transform2d
    {
        private float _x;
        private float _y;
        private float _originX;
        private float _originY;
        private float _rotation = 0;
        private float _sin;
        private float _cos;
        private float _scaleX;
        private float _scaleY;

        private Transform2d _parent;
        private Matrix3 _matrix;

        private uint _revision = 1;
        private uint _matrixRevision = 0;
        
        public Transform2d()
        {
            _matrix.Identity();
        }

        public Transform2d(Transform2d parent)
            : this()
        {
            _parent = parent;
        }

        public uint Revision => _revision;

        public float X
        {
            get => _x;
            set
            {
                _x = value;
                _revision++;
            }
        }

        public float Y
        {
            get => _y;
            set
            {
                _y = value;
                _revision++;
            }
        }

        public float OriginX
        {
            get => _originX;
            set
            {
                _originX = value;
                _revision++;
            }
        }

        public float OriginY
        {
            get => _originY;
            set
            {
                _originY = value;
                _revision++;
            }
        }

        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _revision++;
            }
        }

        public float ScaleX
        {
            get => _scaleX;
            set
            {
                _scaleX = value;
                _revision++;
            }
        }

        public float ScaleY
        {
            get => _scaleY;
            set
            {
                _scaleY = value;
                _revision++;
            }
        }

        public Matrix3 Matrix
        {
            get
            {
                if (_matrixRevision != _revision)
                {
                    BuildMatrix();
                    _matrixRevision = _revision;
                }

                return _matrix;
            }
        }

        public Vector2 Transform(Vector2 vector)
        {
            var matrix = Matrix;
            return new Vector2
            {
                X = matrix.M00 * vector.X + matrix.M20 * vector.Y + matrix.M20,
                Y = matrix.M01 * vector.X + matrix.M11 * vector.Y + matrix.M21
            };
        }

        //    public reset(options: Transform2dOptions = { }){
        //        const opt = { ...defaultOptions, ...options };
        //        this.public float X { get => _x; set => _x = value; }

        //        resetInternal(opt);
        //    }

        //    public transform(x: number, y: number, out: any = new Array(2), offset = 0)
        //    {
        //        const m = this.matrix;

        //        out[offset] = m[0] * x + m[3] * y + m[6];
        //        out[offset + 1] = m[1] * x + m[4] * y + m[7];

        //        return out;
        //    }

        //private resetInternal(opt: Transform2dOptions)
        //{
        //    this.x = opt.x;
        //    this.y = opt.y;
        //    this.scaleX = opt.scaleX;
        //    this.scaleY = opt.scaleY;
        //    this.originX = opt.originX;
        //    this.originY = opt.originY;
        //    this.rotation = opt.rotation;

        //    this._dirty = true;
        //}

        private void BuildMatrix()
        {
            _matrix.M00 = _scaleX * _cos;
            _matrix.M01 = _scaleX * _sin;

            _matrix.M10 = _scaleY * -_sin;
            _matrix.M11 = _scaleY * _cos;

            _matrix.M20 = -_originX * _scaleX * _cos + -_originY * _scaleY * -_sin + _x;
            _matrix.M21 = -_originX * _scaleX * _sin + -_originY * _scaleY * _cos + _y;
        }
    }
}

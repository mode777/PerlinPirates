using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Tgl.Net.Math
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3x3
    {
        public static Matrix3x3 FromMat3x2(Matrix3x2 mat)
        {
            return new Matrix3x3
            {
                M11 = mat.M11,
                M12 = mat.M12,
                M13 = 0,

                M21 = mat.M21,
                M22 = mat.M22,
                M23 = 0,

                M31 = mat.M31,
                M32 = mat.M32,
                M33 = 1
            };
        }

        public float M11;
        public float M12;
        public float M13;

        public float M21;
        public float M22;
        public float M23;

        public float M31;
        public float M32;
        public float M33;

        public void Identity()
        {
            M11 = 1;
            M12 = 0;
            M13 = 0;

            M21 = 0;
            M22 = 1;
            M23 = 0;

            M31 = 0;
            M32 = 0;
            M33 = 1;
        }

        public void Multiply(ref Matrix3x3 b)
        {
            float a00 = M11, a01 = M12, a02 = M13;
            float a10 = M21, a11 = M22, a12 = M23;
            float a20 = M31, a21 = M32, a22 = M33;

            M11 = b.M11 * a00 + b.M12 * a10 + b.M13 * a20;
            M12 = b.M11 * a01 + b.M12 * a11 + b.M13 * a21;
            M13 = b.M11 * a02 + b.M12 * a12 + b.M13 * a22;

            M21 = b.M21 * a00 + b.M22 * a10 + b.M23 * a20;
            M22 = b.M21 * a01 + b.M22 * a11 + b.M23 * a21;
            M23 = b.M21 * a02 + b.M22 * a12 + b.M23 * a22;

            M31 = b.M31 * a00 + b.M32 * a10 + b.M33 * a20;
            M32 = b.M31 * a01 + b.M32 * a11 + b.M33 * a21;
            M33 = b.M31 * a02 + b.M32 * a12 + b.M33 * a22;
        }

        public void Scale(float x, float y)
        {
            M11 *= x;
            M12 *= x;
            M13 *= x;

            M21 *= y;
            M22 *= y;
            M23 *= y;
        }

        public void Translate(float x, float y)
        {
            M31 = x * M11 + y * M21 + M31;
            M32 = x * M12 + y * M22 + M32;
            M33 = x * M13 + y * M23 + M33;
        }

    }
}

//using System.Runtime.InteropServices;
//using System.Xml.Serialization;

//namespace Tgl.Net.Math
//{
//    [StructLayout(LayoutKind.Sequential)]
//    public struct Matrix3
//    {
//        public float M00;
//        public float M01;
//        public float M02;

//        public float M10;
//        public float M11;
//        public float M12;

//        public float M20;
//        public float M21;
//        public float M22;

//        public void Identity()
//        {
//            M00 = 1;
//            M01 = 0;
//            M02 = 0;

//            M10 = 0;
//            M11 = 1;
//            M12 = 0;

//            M20 = 0;
//            M21 = 0;
//            M22 = 1;
//        }

//        public void Multiply(ref Matrix3 b)
//        {
//            float a00 = M00, a01 = M01, a02 = M02;
//            float a10 = M10, a11 = M11, a12 = M12;
//            float a20 = M20, a21 = M21, a22 = M22;
            
//            M00 = b.M00* a00 + b.M01* a10 + b.M02 * a20;
//            M01 = b.M00* a01 + b.M01 * a11 + b.M02 * a21;
//            M02 = b.M00* a02 + b.M01 * a12 + b.M02 * a22;

//            M10 = b.M10* a00 + b.M11 * a10 + b.M12 * a20;
//            M11 = b.M10* a01 + b.M11 * a11 + b.M12 * a21;
//            M12 = b.M10* a02 + b.M11 * a12 + b.M12 * a22;

//            M20 = b.M20* a00 + b.M21 * a10 + b.M22 * a20;
//            M21 = b.M20* a01 + b.M21 * a11 + b.M22 * a21;
//            M22 = b.M20* a02 + b.M21 * a12 + b.M22 * a22;
//        }

//        public void Scale(float x, float y)
//        {
//            M00 *= x;
//            M01 *= x;
//            M02 *= x;

//            M10 *= y;
//            M11 *= y;
//            M12 *= y;
//        }

//        public void Translate(float x, float y)
//        {
//            M20 = x * M00 + y * M10 + M20;
//            M21 = x * M01 + y * M11 + M21;
//            M22 = x * M02 + y * M12 + M22;
//        }

//    }
//}

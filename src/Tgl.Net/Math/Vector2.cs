//using System;
//using System.Runtime.InteropServices;

//namespace Tgl.Net.Math
//{
//    [StructLayout(LayoutKind.Sequential)]
//    public struct Vector2 : IEquatable<Vector2>
//    {
//        public float X;
//        public float Y;

//        public bool Equals(Vector2 other)
//        {
//            return X.Equals(other.X) && Y.Equals(other.Y);
//        }

//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            return obj is Vector2 other && Equals(other);
//        }

//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
//            }
//        }

//        public static bool operator ==(Vector2 left, Vector2 right)
//        {
//            return left.Equals(right);
//        }

//        public static bool operator !=(Vector2 left, Vector2 right)
//        {
//            return !left.Equals(right);
//        }

//        public void Transform(ref Matrix3 mat)
//        {
//            var x = X;
//            var y = Y;
//            X = mat.M00 * x + mat.M10 * y + mat.M20;
//            Y = mat.M01 * x + mat.M11 * y + mat.M21;
//        }

//        public void Offset(float x, float y)
//        {
//            X += x;
//            Y += y;
//        }
//    }
//}

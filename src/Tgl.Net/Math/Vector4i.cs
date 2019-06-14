//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace Tgl.Net.Math
//{
//    [StructLayout(LayoutKind.Sequential)]
//    public struct Vector4i : IEquatable<Vector4i>
//    {
//        public int X;
//        public int Y;
//        public int Z;
//        public int W;

//        public bool Equals(Vector4i other)
//        {
//            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
//        }

//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            return obj is Vector4i other && Equals(other);
//        }

//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                var hashCode = X;
//                hashCode = (hashCode * 397) ^ Y;
//                hashCode = (hashCode * 397) ^ Z;
//                hashCode = (hashCode * 397) ^ W;
//                return hashCode;
//            }
//        }

//        public static bool operator ==(Vector4i left, Vector4i right)
//        {
//            return left.Equals(right);
//        }

//        public static bool operator !=(Vector4i left, Vector4i right)
//        {
//            return !left.Equals(right);
//        }
//    }
//}

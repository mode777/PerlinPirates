//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace Tgl.Net.Math
//{
//    [StructLayout(LayoutKind.Sequential)]
//    public struct Vector4b : IEquatable<Vector4b>
//    {
//        public bool X;
//        public bool Y;
//        public bool Z;
//        public bool W;

//        public bool Equals(Vector4b other)
//        {
//            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
//        }

//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            return obj is Vector4b other && Equals(other);
//        }

//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                var hashCode = X.GetHashCode();
//                hashCode = (hashCode * 397) ^ Y.GetHashCode();
//                hashCode = (hashCode * 397) ^ Z.GetHashCode();
//                hashCode = (hashCode * 397) ^ W.GetHashCode();
//                return hashCode;
//            }
//        }

//        public static bool operator ==(Vector4b left, Vector4b right)
//        {
//            return left.Equals(right);
//        }

//        public static bool operator !=(Vector4b left, Vector4b right)
//        {
//            return !left.Equals(right);
//        }
//    }
//}

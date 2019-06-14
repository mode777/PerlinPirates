//using System;
//using System.Runtime.InteropServices;

//namespace Tgl.Net.Math
//{
//    [StructLayout(LayoutKind.Sequential)]
//    public struct Vector2i : IEquatable<Vector2i>
//    {
//        public int X;
//        public int Y;

//        public bool Equals(Vector2i other)
//        {
//            return X == other.X && Y == other.Y;
//        }

//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            return obj is Vector2i other && Equals(other);
//        }

//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                return (X * 397) ^ Y;
//            }
//        }

//        public static bool operator ==(Vector2i left, Vector2i right)
//        {
//            return left.Equals(right);
//        }

//        public static bool operator !=(Vector2i left, Vector2i right)
//        {
//            return !left.Equals(right);
//        }
//    }
//}
